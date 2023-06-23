using ERP.Application.ViewModels;

namespace ERP.Application.Interfaces
{
    public  interface IProductAppService
    {
        Task<List<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(int id);
        Task Insert(ProductInsertViewModel productViewModel);
        Task Update(int id, ProductEditViewModel productViewModel);
        Task Delete(int id);
    }
}
