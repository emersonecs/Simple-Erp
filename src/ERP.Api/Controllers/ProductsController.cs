using ERP.Application.Interfaces;
using ERP.Application.ViewModels;
using ERP.Domain.Notification;
using ERP.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductAppService _productAppService;
        private readonly IUnitOfWork _uow;

        public ProductsController(NotificationContext notificationContext, IProductAppService productAppService, IUnitOfWork uow) : base(notificationContext)
        {
            _productAppService = productAppService;
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lst = await _productAppService.GetAll();

            return Response(lst);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var obj = await _productAppService.GetById(id);

            return Response(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ProductInsertViewModel productViewModel)
        {
            await _productAppService.Insert(productViewModel);

            await _uow.SaveChangesAsync();

            return Response();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductEditViewModel productViewModel)
        {
            await _productAppService.Update(id, productViewModel);

            await _uow.SaveChangesAsync();

            return Response();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productAppService.Delete(id);

            await _uow.SaveChangesAsync();

            return Response();
        }
    }
}
