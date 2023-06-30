using AutoMapper;
using ERP.Application.Interfaces;
using ERP.Application.ViewModels;
using ERP.Domain.Interfaces;
using ERP.Domain.Models;
using ERP.Domain.Notification;
using ERP.Infra.Data.Context;

namespace ERP.Application.Services
{
    public class ClientAppService : IClientAppService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly NotificationContext _notificationContext;
        private readonly IUnitOfWork _uow;

        public ClientAppService(IMapper mapper, IClientRepository clientRepository, NotificationContext notificationContext, IUnitOfWork uow)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _notificationContext = notificationContext;
            _uow = uow;
        }

        public async Task<List<ClientViewModel>> GetAll()
        {
            var lst = await _clientRepository.GetAll();

            return _mapper.Map<List<ClientViewModel>>(lst);
        }

        public async Task<ClientViewModel> GetById(int id)
        {
            var obj = await _clientRepository.GetById(id);

            return _mapper.Map<ClientViewModel>(obj);
        }

        public async Task Insert(ClientInsertViewModel clientViewModel)
        {
            var obj = _mapper.Map<Client>(clientViewModel);

            await _clientRepository.Insert(obj);

            await _uow.SaveChangesAsync();
        }

        public async Task Update(int id, ClientEditViewModel clientViewModel)
        {
            var client = await _clientRepository.GetById(id);
            if (client is null)
            {
                _notificationContext.AddNotification("Client", "Client not found.");
                return;
            }

            client.Update(clientViewModel.Name, clientViewModel.Address, clientViewModel.District, clientViewModel.Number, clientViewModel.Email, clientViewModel.Phone);

            _clientRepository.Update(client);

            await _uow.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var client = await _clientRepository.GetById(id);
            if (client is null)
            {
                _notificationContext.AddNotification("Client", "Client not found.");
                return;
            }

            _clientRepository.Delete(client);

            await _uow.SaveChangesAsync();
        }
    }
}
