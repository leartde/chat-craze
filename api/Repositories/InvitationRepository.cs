using api.Contracts;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class InvitationRepository : RepositoryBase<Invitation>, IInvitationRepository
{
    public InvitationRepository(ApplicationDbContext context) : base(context) { }
    public async Task<IEnumerable<Invitation>> GetInvitationsForSenderAsync(string senderId)
    {
        return await FindByCondition(i => i.SenderId.Equals(senderId))
            .Include(i => i.Sender)
            .Include(i => i.Receiver)
            .ToListAsync();
    }

    public async Task<IEnumerable<Invitation>> GetInvitationsForReceiverAsync(string receiverId)
    {
        return await FindByCondition(i => i.ReceiverId.Equals(receiverId))
            .Include(i => i.Sender)
            .Include(i => i.Receiver)
            .ToListAsync();
    }

    public void CreateInvitation(Invitation invitation)
    {
        Create(invitation);
    }

    public void UpdateInvitation(Invitation invitation)
    {
        Update(invitation);
    }

    public void DeleteInvitation(Invitation invitation)
    {
        Delete(invitation);
    }
}