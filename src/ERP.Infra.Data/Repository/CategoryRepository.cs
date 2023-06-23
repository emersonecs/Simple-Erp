using ERP.Domain.Interfaces;
using ERP.Domain.Models;
using ERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infra.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly AppDbContext DbContext;
        protected readonly DbSet<Category> DbSet;

        public CategoryRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<Category>();
        }

        public async Task<List<Category>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Insert(Category obj)
        {
            await DbSet.AddAsync(obj);
        }

        public void Update(Category obj)
        {
            DbSet.Update(obj);
        }

        public void Delete(Category obj)
        {
            DbSet.Remove(obj);
        }
    }
}
