using System.Net;
using ERP.Domain.Notification;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ERP.Api.Configurations
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext _notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {

            if (context.ModelState.Count > 0)
            {
                var addNow = false;

                foreach (var key in context.ModelState.Keys)
                {
                    var modelErrorCollection = context.ModelState[key]?.Errors;
                    if (modelErrorCollection == null) continue;

                    foreach (var error in modelErrorCollection)
                    {
                        addNow = true;
                        _notificationContext.AddNotification(key, error.ErrorMessage);
                    }
                }

                if (addNow && _notificationContext.HasNotifications)
                {
                    var objReturn = new
                    {
                        success = false,
                        errors = _notificationContext.Notifications
                    };

                    var notifications = JsonConvert.SerializeObject(objReturn);

                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.HttpContext.Response.ContentType = "application/json";
                    await context.HttpContext.Response.WriteAsync(notifications);

                    return;
                }
            }

            await next();
        }
    }
}
