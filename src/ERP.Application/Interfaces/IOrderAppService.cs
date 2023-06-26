using ERP.Application.ViewModels;

namespace ERP.Application.Interfaces
{
    public  interface IOrderAppService
    {
        Task Insert(OrderInsertViewModel orderViewModel);
    }
}
