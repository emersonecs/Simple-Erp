using AutoMapper;
using ERP.Application.Interfaces;
using ERP.Application.ViewModels;
using ERP.Domain.Interfaces;
using ERP.Domain.Models;
using ERP.Domain.Notification;

namespace ERP.Application.Services
{
    public class SupplierAppService : ISupplierAppService
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        private readonly NotificationContext _notificationContext;

        public SupplierAppService(IMapper mapper, ISupplierRepository supplierRepository, NotificationContext notificationContext)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _notificationContext = notificationContext;
        }

        public async Task<List<SupplierViewModel>> GetAll()
        {
            var lst = await _supplierRepository.GetAll();

            return _mapper.Map<List<SupplierViewModel>>(lst);
        }

        public async Task<SupplierViewModel> GetById(int id)
        {
            var obj = await _supplierRepository.GetById(id);

            return _mapper.Map<SupplierViewModel>(obj);
        }

        public async Task Insert(SupplierInsertViewModel supplierViewModel)
        {
            var obj = _mapper.Map<Supplier>(supplierViewModel);

            await _supplierRepository.Insert(obj);
        }

        public async Task Update(int id, SupplierEditViewModel supplierViewModel)
        {
            var supplier = await _supplierRepository.GetById(id);
            if (supplier is null)
            {
                _notificationContext.AddNotification("Supplier", "Supplier not found.");
                return;
            }

            supplier.Update(supplierViewModel.Name, supplierViewModel.Address, supplierViewModel.PhoneNumber, supplierViewModel.Email);

            _supplierRepository.Update(supplier);
        }

        public async Task Delete(int id)
        {
            var supplier = await _supplierRepository.GetById(id);
            if (supplier is null)
            {
                _notificationContext.AddNotification("Supplier", "Supplier not found.");
                return;
            }

            _supplierRepository.Delete(supplier);
        }
    }
}
