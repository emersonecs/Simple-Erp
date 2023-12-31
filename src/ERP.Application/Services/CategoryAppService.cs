using AutoMapper;
using ERP.Application.Interfaces;
using ERP.Application.ViewModels;
using ERP.Domain.Interfaces;
using ERP.Domain.Models;
using ERP.Domain.Notification;
using ERP.Infra.Data.Context;

namespace ERP.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly NotificationContext _notificationContext;
        private readonly IUnitOfWork _uow;

        public CategoryAppService(IMapper mapper, ICategoryRepository categoryRepository, NotificationContext notificationContext, IUnitOfWork uow)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _notificationContext = notificationContext;
            _uow = uow;
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            var lst = await _categoryRepository.GetAll();

            return _mapper.Map<List<CategoryViewModel>>(lst);
        }

        public async Task<CategoryViewModel> GetById(int id)
        {
            var obj = await _categoryRepository.GetById(id);

            return _mapper.Map<CategoryViewModel>(obj);
        }

        public async Task Insert(CategoryInsertViewModel categoryViewModel)
        {
            var obj = _mapper.Map<Category>(categoryViewModel);

            await _categoryRepository.Insert(obj);

            await _uow.SaveChangesAsync();
        }

        public async Task Update(int id, CategoryEditViewModel categoryViewModel)
        {
            var category = await _categoryRepository.GetById(id);
            if (category is null)
            {
                _notificationContext.AddNotification("Category", "Category not found.");
                return;
            }

            category.Update(categoryViewModel.Name, categoryViewModel.Description);

            _categoryRepository.Update(category);

            await _uow.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category is null)
            {
                _notificationContext.AddNotification("Category", "Category not found.");
                return;
            }

            _categoryRepository.Delete(category);

            await _uow.SaveChangesAsync();
        }
    }
}
