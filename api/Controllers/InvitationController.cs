using api.DataTransferObjects.InvitationDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/users/{userId}/invitations")]
    public class InvitationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public InvitationController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("sent")]
        public async Task<IActionResult> GetInvitationsForSender(string userId)
        {
            var invitations = await _service.InvitationService.GetInvitationsForSenderAsync(userId);
            return Ok(invitations);

        }

        [HttpGet("received")]
        public async Task<IActionResult> GetInvitationsForReceiver(string userId)
        {

            var invitations = await _service.InvitationService.GetInvitationsForReceiverAsync(userId);
            return Ok(invitations);

        }

        [HttpPost]
        public async Task<IActionResult> CreateInvitation( string userId, string receiverId)
        {
            await _service.InvitationService.CreateInvitationAsync(userId, receiverId);
            return Ok("Invitation succesfully sent");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInvitation(string userId, string receiverId)
        {
            await _service.InvitationService.CancelInvitationAsync(userId, receiverId);
            return Ok("Invitation successfully canceled");
        }

        [HttpPut("decline")]
        public async Task<IActionResult> DeclineInvitation(string senderId, string userId)
        {
            await _service.InvitationService.DeclineInvitationAsync(senderId, userId);
            return Ok("Invitation succesfully declined");
        }
    }
}