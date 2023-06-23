namespace ERP.Infra.Data.Context
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
