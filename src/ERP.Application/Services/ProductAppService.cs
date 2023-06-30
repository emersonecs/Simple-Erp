using AutoMapper;
using ERP.Application.Interfaces;
using ERP.Application.ViewModels;
using ERP.Domain.Interfaces;
using ERP.Domain.Models;
using ERP.Domain.Notification;
using ERP.Infra.Data.Context;

namespace ERP.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly NotificationContext _notificationContext;
        private readonly IUnitOfWork _uow;

        public ProductAppService(IMapper mapper, IProductRepository productRepository, NotificationContext notificationContext, IUnitOfWork uow)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _notificationContext = notificationContext;
            _uow = uow;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var lst = await _productRepository.GetAll();

            return _mapper.Map<List<ProductViewModel>>(lst);
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            var obj = await _productRepository.GetById(id);

            return _mapper.Map<ProductViewModel>(obj);
        }

        public async Task Insert(ProductInsertViewModel productViewModel)
        {
            var obj = _mapper.Map<Product>(productViewModel);

            await _productRepository.Insert(obj);

            await _uow.SaveChangesAsync();
        }

        public async Task Update(int id, ProductEditViewModel productViewModel)
        {
            var product = await _productRepository.GetById(id);
            if (product is null)
            {
                _notificationContext.AddNotification("Product", "Product not found.");
                return;
            }

            product.Update(productViewModel.Name, productViewModel.Description, productViewModel.BarCode, productViewModel.Price, productViewModel.StockQuantity, productViewModel.SupplierId, productViewModel.CategoryId);

            _productRepository.Update(product);

            await _uow.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product is null)
            {
                _notificationContext.AddNotification("Product", "Product not found.");
                return;
            }

            _productRepository.Delete(product);

            await _uow.SaveChangesAsync();
        }
    }
}
