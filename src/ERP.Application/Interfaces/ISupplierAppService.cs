using ERP.Application.ViewModels;

namespace ERP.Application.Interfaces
{
    public  interface ISupplierAppService
    {
        Task<List<SupplierViewModel>> GetAll();
        Task<SupplierViewModel> GetById(int id);
        Task Insert(SupplierInsertViewModel supplierViewModel);
        Task Update(int id, SupplierEditViewModel supplierViewModel);
        Task Delete(int id);
    }
}
