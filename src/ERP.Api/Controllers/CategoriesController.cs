using ERP.Application.Interfaces;
using ERP.Application.ViewModels;
using ERP.Domain.Notification;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoriesController(NotificationContext notificationContext, ICategoryAppService categoryAppService) : base(notificationContext)
        {
            _categoryAppService = categoryAppService;
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

            return Response();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryEditViewModel categoryViewModel)
        {
            await _categoryAppService.Update(id, categoryViewModel);

            return Response();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryAppService.Delete(id);

            return Response();
        }
    }
}
