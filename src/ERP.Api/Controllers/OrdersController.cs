using ERP.Application.Interfaces;
using ERP.Application.ViewModels;
using ERP.Domain.Notification;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IOrderAppService _orderAppService;

        public OrdersController(NotificationContext notificationContext, IOrderAppService orderAppService) : base(notificationContext)
        {
            _orderAppService = orderAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] OrderInsertViewModel orderViewModel)
        {
            await _orderAppService.Insert(orderViewModel);

            return Response();
        }
    }
}
