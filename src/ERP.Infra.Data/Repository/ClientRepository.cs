using ERP.Domain.Interfaces;
using ERP.Domain.Models;
using ERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infra.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        protected readonly AppDbContext DbContext;
        protected readonly DbSet<Client> DbSet;

        public ClientRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<Client>();
        }

        public async Task<List<Client>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Client> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Insert(Client obj)
        {
            await DbSet.AddAsync(obj);
        }

        public void Update(Client obj)
        {
            DbSet.Update(obj);
        }

        public void Delete(Client obj)
        {
            DbSet.Remove(obj);
        }
    }
}
