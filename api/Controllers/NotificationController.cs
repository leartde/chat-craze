using api.DataTransferObjects.NotificationDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
   [ApiController]
   [Route("/api/users/{userId}/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public NotificationController(IServiceManager service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetNotificationsForReceiver(string userId)
        {
            var notifications = await _service
                .NotificationService.GetNotificationsForReceiverAsync(userId);
            return Ok(notifications);
        }


    }
}