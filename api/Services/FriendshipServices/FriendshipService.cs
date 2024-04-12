using api.Contracts;
using api.DataTransferObjects.FriendshipDtos;
using api.DataTransferObjects.NotificationDtos;
using api.Exceptions;
using api.Models;
using AutoMapper;

namespace api.Services.FriendshipServices;

public class FriendshipService : IFriendshipService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public FriendshipService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FriendshipDto>> GetFriendshipsForUserAsync(string userId)
    {
        await CheckIfUserExistsAsync(userId);
        var friendships = await _repository.Friendship.GetFriendshipsForUserAsync(userId);
        return _mapper.Map<IEnumerable<FriendshipDto>>(friendships);
    }

    public async  Task CreateFriendshipAsync(string friendOneId, string friendTwoId)
    {
        await ValidateFriendshipAsync(friendOneId, friendTwoId);
        var friendship = new Friendship
        {
            FriendOneId = friendOneId,
            FriendTwoId = friendTwoId
        };
        _repository.Friendship.CreateFriendship(friendship);
        await SendFriendshipAcceptedNotificationAsync(friendOneId, friendTwoId);
        await _repository.SaveAsync();
    }

    public async Task DeleteFriendshipAsync(string friendOneId, string friendTwoId)
    {
        var friendships = await _repository.Friendship.GetFriendshipsForUserAsync(friendOneId);
        var friendshipToDelete = friendships
            .FirstOrDefault(f => (f.FriendOneId.Equals(friendOneId) &&
                                   f.FriendTwoId.Equals(friendTwoId)) ||
                                  (f.FriendOneId.Equals(friendTwoId)
                                   && f.FriendTwoId.Equals(friendOneId))
                );
        if (friendshipToDelete is null) throw new NotFoundException("Friendship not found");
            _repository.Friendship.DeleteFriendship(friendshipToDelete);
            await _repository.SaveAsync();
    }

    private async Task ValidateFriendshipAsync(string friendOneId, string friendTwoId)
    {
        await CheckIfUserExistsAsync(friendOneId);
        await CheckIfUserExistsAsync(friendTwoId);
        await CheckIfFriendshipExistsAsync(friendOneId, friendTwoId);
        if (friendOneId.Equals(friendTwoId))
            throw new BadRequestException("Ids can't be equal.");
        var invitations = await _repository.Invite.GetInvitationsForSenderAsync(friendOneId);
        if (invitations == null || !invitations.Any(i => i.ReceiverId.Equals(friendTwoId)))
            throw new BadRequestException("No invite for this friendship exists.");
        //TODO - logic for checking if currentUser is friendOne 
    }

    private async Task CheckIfFriendshipExistsAsync(string friendOneId, string friendTwoId)
    {
        var friendshipsDto = await _repository.Friendship.GetFriendshipsForUserAsync(friendOneId);
        if (friendshipsDto != null && friendshipsDto.Any(friendshipDto => (friendshipDto.FriendOneId.Equals(friendOneId)
                                                                           && friendshipDto.FriendTwoId.Equals(
                                                                               friendTwoId)) ||
                                                                          (friendshipDto.FriendOneId.Equals(friendTwoId)
                                                                           && friendshipDto.FriendTwoId.Equals(
                                                                               friendOneId))))
            throw new BadRequestException("Users are already friends");
        await SetStatusToAcceptedAsync(friendOneId, friendTwoId);
    }

    private async Task SetStatusToAcceptedAsync(string senderId, string receiverId)
    {
        var invitations = await _repository.Invite.GetInvitationsForSenderAsync(senderId);
        if (invitations == null) throw new ArgumentNullException(nameof(invitations));
        var invitation = invitations.FirstOrDefault(i => i.ReceiverId.Equals(receiverId));
        if (invitation != null)
        {
            invitation.Status = "Accepted";
            _repository.Invite.UpdateInvitation(invitation);
        }
    }

    private async Task SendFriendshipAcceptedNotificationAsync(string senderId, string receiverId)
    {
        var sender = await _repository.User.GetUserAsync(senderId);
        var addNotificationDto = new AddNotificationDto
        {
            SenderId = senderId,
            ReceiverId = receiverId,
            Content = $"{sender.UserName} has accepted your friendship request!"
        };
        var notification = _mapper.Map<Notification>(addNotificationDto);
        _repository.Notification.CreateNotification(notification);
    }

    private async Task CheckIfUserExistsAsync(string userId)
    {
        var user = await _repository.User.GetUserAsync(userId);
        if (user is null) throw new NotFoundException($"User with id {userId} not found.");
    }
}