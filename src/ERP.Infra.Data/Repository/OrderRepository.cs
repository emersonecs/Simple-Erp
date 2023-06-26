using ERP.Domain.Interfaces;
using ERP.Domain.Models;
using ERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infra.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly AppDbContext DbContext;
        protected readonly DbSet<Order> DbSet;

        public OrderRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<Order>();
        }

        public async Task Insert(Order obj)
        {
            await DbSet.AddAsync(obj);
        }
    }
}
