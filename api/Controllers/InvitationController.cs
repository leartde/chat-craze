using api.DataTransferObjects.InvitationDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/invitations")]
    public class InvitationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public InvitationController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("sender/{senderId}")]
        public async Task<IActionResult> GetInvitationsForSender(string senderId)
        {
            var invitations = await _service.InvitationService.GetInvitationsForSenderAsync(senderId);
            return Ok(invitations);

        }

        [HttpGet("receiver/{receiverId}")]
        public async Task<IActionResult> GetInvitationsForReceiver(string receiverId)
        {

            var invitations = await _service.InvitationService.GetInvitationsForReceiverAsync(receiverId);
            return Ok(invitations);

        }

        [HttpPost]
        public async Task<IActionResult> CreateInvitation([FromBody] AddInvitationDto invitationDto)
        {
            await _service.InvitationService.CreateInvitationAsync(invitationDto);
            return Ok("Invitation succesfully sent");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInvitation(DeleteInvitationDto deleteInvitationDto)
        {
            await _service.InvitationService.CancelInvitationAsync(deleteInvitationDto);
            return Ok("Invitation successfully canceled");
        }

        [HttpPut("decline")]
        public async Task<IActionResult> DeclineInvitation(UpdateInvitationDto updateInvitationDto)
        {
            await _service.InvitationService.DeclineInvitationAsync(updateInvitationDto);
            return Ok("Invitation succesfully declined");
        }
    }
}