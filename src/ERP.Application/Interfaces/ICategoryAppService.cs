using ERP.Application.ViewModels;

namespace ERP.Application.Interfaces
{
    public  interface ICategoryAppService
    {
        Task<List<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> GetById(int id);
        Task Insert(CategoryInsertViewModel categoryViewModel);
        Task Update(int id, CategoryEditViewModel categoryViewModel);
        Task Delete(int id);
    }
}
