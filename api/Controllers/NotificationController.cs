using api.DataTransferObjects.NotificationDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
   [ApiController]
   [Route("/api/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public NotificationController(IServiceManager service)
        {
            _service = service;
        }
        [HttpGet("{receiverId}")]
        public async Task<IActionResult> GetNotificationsForReceiver(string receiverId)
        {
            var notifications = await _service
                .NotificationService.GetNotificationsForReceiverAsync(receiverId);
            return Ok(notifications);
        }


    }
}