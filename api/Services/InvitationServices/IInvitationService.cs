using api.DataTransferObjects.InvitationDtos;

namespace api.Services.InvitationServices;

public interface IInvitationService
{
    Task<IEnumerable<InvitationDto>> GetInvitationsForSenderAsync(string senderId);
    Task<IEnumerable<InvitationDto>> GetInvitationsForReceiverAsync(string receiverId);
    Task CreateInvitationAsync(string senderId, string receiverId);
    Task CancelInvitationAsync(string senderId, string receiverId);
    Task DeclineInvitationAsync(string senderId, string receiverId);
}