using ERP.Domain.Notification;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly NotificationContext _notificationContext;

        public BaseController(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        protected IEnumerable<Notification> Notifications => _notificationContext.Notifications;

        protected bool IsValidOperation()
        {
            return !_notificationContext.HasNotifications;
        }

        protected new IActionResult Response(object? result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    Success = true,
                    Data = result
                });
            }

            return BadRequest(new
            {
                Success = false,
                Errors = Notifications
            });
        }
    }
}
