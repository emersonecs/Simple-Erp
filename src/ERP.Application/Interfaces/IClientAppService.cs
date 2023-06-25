using ERP.Application.ViewModels;

namespace ERP.Application.Interfaces
{
    public  interface IClientAppService
    {
        Task<List<ClientViewModel>> GetAll();
        Task<ClientViewModel> GetById(int id);
        Task Insert(ClientInsertViewModel clientViewModel);
        Task Update(int id, ClientEditViewModel clientViewModel);
        Task Delete(int id);
    }
}
