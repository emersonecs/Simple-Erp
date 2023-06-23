using ERP.Domain.Notification;

namespace ERP.Infra.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext DbContext;
        protected readonly NotificationContext NotificationContext;

        public UnitOfWork(AppDbContext dbContext, NotificationContext notificationContext)
        {
            DbContext = dbContext;
            NotificationContext = notificationContext;
        }
        public async Task SaveChangesAsync()
        {
            try
            {
                if (!NotificationContext.HasNotifications)
                    await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                NotificationContext.AddNotification("Error", ex.Message);

            }
        }
    }
}
