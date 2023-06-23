using ERP.Domain.Interfaces;
using ERP.Domain.Models;
using ERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infra.Data.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        protected readonly AppDbContext DbContext;
        protected readonly DbSet<Supplier> DbSet;

        public SupplierRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<Supplier>();
        }

        public async Task<List<Supplier>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Insert(Supplier obj)
        {
            await DbSet.AddAsync(obj);
        }

        public void Update(Supplier obj)
        {
            DbSet.Update(obj);
        }

        public void Delete(Supplier obj)
        {
            DbSet.Remove(obj);
        }
    }
}
