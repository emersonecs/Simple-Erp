using ERP.Application.Interfaces;
using ERP.Application.ViewModels;
using ERP.Domain.Notification;
using ERP.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IUnitOfWork _uow;

        public CategoriesController(NotificationContext notificationContext, ICategoryAppService categoryAppService, IUnitOfWork uow) : base(notificationContext)
        {
            _categoryAppService = categoryAppService;
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lst = await _categoryAppService.GetAll();

            return Response(lst);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var obj = await _categoryAppService.GetById(id);

            return Response(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CategoryInsertViewModel categoryViewModel)
        {
            await _categoryAppService.Insert(categoryViewModel);

            await _uow.SaveChangesAsync();

            return Response();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryEditViewModel categoryViewModel)
        {
            await _categoryAppService.Update(id, categoryViewModel);

            await _uow.SaveChangesAsync();

            return Response();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryAppService.Delete(id);

            await _uow.SaveChangesAsync();

            return Response();
        }
    }
}
