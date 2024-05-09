using api.Contracts;
using api.DataTransferObjects.InvitationDtos;
using api.DataTransferObjects.NotificationDtos;
using api.Exceptions;
using api.Models;
using AutoMapper;

namespace api.Services.InvitationServices;

internal sealed class InvitationService : IInvitationService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    public InvitationService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<InvitationDto>> GetInvitationsForSenderAsync(string senderId)
    {
        await CheckIfUserExistsAsync(senderId);
        var invitations =  await _repository.Invite.GetInvitationsForSenderAsync(senderId);
        return _mapper.Map<IEnumerable<InvitationDto>>(invitations);
    }

    public async Task<IEnumerable<InvitationDto>> GetInvitationsForReceiverAsync(string receiverId)
    {
        await CheckIfUserExistsAsync(receiverId);
        var invitations =  await _repository.Invite.GetInvitationsForReceiverAsync(receiverId);
        return _mapper.Map<IEnumerable<InvitationDto>>(invitations);
    }

    public async Task CreateInvitationAsync(string senderId, string receiverId)
    {
        await ValidateInvitationAsync(senderId, receiverId);
        var invitation = new Invitation
        {
            SenderId = senderId,
            ReceiverId = receiverId
        };
        _repository.Invite.CreateInvitation(invitation);
        await SendInviteNotificationAsync(senderId, receiverId);
        await _repository.SaveAsync();
    }

    public async Task CancelInvitationAsync(string senderId, string receiverId)
    {
        var invitations = await _repository.Invite
            .GetInvitationsForSenderAsync(senderId);
        var invitationToDelete = invitations
            .FirstOrDefault(i => i.ReceiverId.Equals(receiverId));
        if (invitationToDelete is null) throw new NotFoundException("Invitation not found");
            _repository.Invite.DeleteInvitation(invitationToDelete);
            await _repository.SaveAsync();
        
    }

    public async Task DeclineInvitationAsync(string senderId, string receiverId)
    {
        var invitations = await _repository
            .Invite.GetInvitationsForReceiverAsync(receiverId);
        var invitationToDecline = invitations
            .FirstOrDefault(i => i.SenderId.Equals(senderId));
        if (invitationToDecline is null) throw new NotFoundException("Invitation not found");
            invitationToDecline.Status = "Declined";
            _repository.Invite.UpdateInvitation(invitationToDecline);
            await _repository.SaveAsync();
        
    }

    private async Task ValidateInvitationAsync(string senderId, string receiverId)
    {
        await CheckIfUserExistsAsync(senderId);
        await CheckIfUserExistsAsync(receiverId);
        if (senderId.Equals(receiverId))
            throw new BadRequestException("SenderId and ReceiverId are equal");
        await CheckIfInviteExistsAsync(senderId,receiverId);
    }
    private async Task SendInviteNotificationAsync(string senderId, string receiverId)
    {
        var sender = await _repository.User.GetUserAsync(senderId);
        if (sender is null) throw new NotFoundException($"User with id {senderId} not found");
        var addNotificationDto = new AddNotificationDto
        {
            SenderId = senderId,
            ReceiverId = receiverId,
            Content = $"{sender.UserName} has sent you a friendship request!"
        };
        var notification = _mapper.Map<Notification>(addNotificationDto);
        _repository.Notification.CreateNotification(notification);
    }
    
    private async Task CheckIfUserExistsAsync(string userId)
    {
        var user = await _repository.User.GetUserAsync(userId);
        if (user is null) throw new NotFoundException($"User with id {userId} not found.");
    }

    private async Task CheckIfInviteExistsAsync(string senderId, string receiverId)
    {
        var invitationsDto = await _repository.Invite.GetInvitationsForSenderAsync(senderId);
        if (invitationsDto != null && invitationsDto.Any(invitationDto => invitationDto.ReceiverId.Equals(receiverId)))
            throw new BadRequestException("Friend invite already exists");

    }
}