using ERP.Application.Interfaces;
using ERP.Application.ViewModels;
using ERP.Domain.Notification;
using ERP.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : BaseController
    {
        private readonly IClientAppService _clientAppService;
        private readonly IUnitOfWork _uow;

        public ClientsController(NotificationContext notificationContext, IClientAppService clientAppService, IUnitOfWork uow) : base(notificationContext)
        {
            _clientAppService = clientAppService;
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lst = await _clientAppService.GetAll();

            return Response(lst);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var obj = await _clientAppService.GetById(id);

            return Response(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ClientInsertViewModel clientViewModel)
        {
            await _clientAppService.Insert(clientViewModel);

            await _uow.SaveChangesAsync();

            return Response();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClientEditViewModel clientViewModel)
        {
            await _clientAppService.Update(id, clientViewModel);

            await _uow.SaveChangesAsync();

            return Response();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientAppService.Delete(id);

            await _uow.SaveChangesAsync();

            return Response();
        }
    }
}
