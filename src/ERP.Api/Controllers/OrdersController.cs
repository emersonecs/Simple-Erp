using ERP.Application.Interfaces;
using ERP.Application.ViewModels;
using ERP.Domain.Notification;
using ERP.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IUnitOfWork _uow;

        public OrdersController(NotificationContext notificationContext, IOrderAppService orderAppService, IUnitOfWork uow) : base(notificationContext)
        {
            _orderAppService = orderAppService;
            _uow = uow;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] OrderInsertViewModel orderViewModel)
        {
            await _orderAppService.Insert(orderViewModel);

            await _uow.SaveChangesAsync();

            return Response();
        }
    }
}
