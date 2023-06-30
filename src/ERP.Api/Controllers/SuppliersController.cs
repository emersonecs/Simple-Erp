using ERP.Application.Interfaces;
using ERP.Application.ViewModels;
using ERP.Domain.Notification;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : BaseController
    {
        private readonly ISupplierAppService _supplierAppService;

        public SuppliersController(NotificationContext notificationContext, ISupplierAppService supplierAppService) : base(notificationContext)
        {
            _supplierAppService = supplierAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lst = await _supplierAppService.GetAll();

            return Response(lst);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var obj = await _supplierAppService.GetById(id);

            return Response(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] SupplierInsertViewModel supplierViewModel)
        {
            await _supplierAppService.Insert(supplierViewModel);

            return Response();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SupplierEditViewModel supplierViewModel)
        {
            await _supplierAppService.Update(id, supplierViewModel);

            return Response();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _supplierAppService.Delete(id);
            
            return Response();
        }
    }
}
