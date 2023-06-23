using ERP.Domain.Interfaces;
using ERP.Domain.Models;
using ERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected readonly AppDbContext DbContext;
        protected readonly DbSet<Product> DbSet;

        public ProductRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<Product>();
        }

        public async Task<List<Product>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Insert(Product obj)
        {
            await DbSet.AddAsync(obj);
        }

        public void Update(Product obj)
        {
            DbSet.Update(obj);
        }

        public void Delete(Product obj)
        {
            DbSet.Remove(obj);
        }
    }
}
