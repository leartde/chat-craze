using api.DataTransferObjects.InvitationDtos;

namespace api.Services.InvitationServices;

public interface IInvitationService
{
    Task<IEnumerable<InvitationDto>> GetInvitationsForSenderAsync(string senderId);
    Task<IEnumerable<InvitationDto>> GetInvitationsForReceiverAsync(string receiverId);
    Task CreateInvitationAsync(AddInvitationDto addInvitationDto);
    Task CancelInvitationAsync(DeleteInvitationDto deleteInvitationDto);
    Task DeclineInvitationAsync(UpdateInvitationDto deleteInvitationDto);
}