using api.DataTransferObjects.InvitationDtos;
using api.Models;

namespace api.Contracts;

public interface IInvitationRepository
{
     Task<IEnumerable<Invitation>> GetInvitationsForSenderAsync(string senderId);
     Task<IEnumerable<Invitation>> GetInvitationsForReceiverAsync(string receiverId);
     void CreateInvitation(Invitation invitation);
     void UpdateInvitation(Invitation invitation);
     void DeleteInvitation(Invitation invitation);
}