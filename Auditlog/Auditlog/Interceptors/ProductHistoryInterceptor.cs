using AdvanceSolutionSample.AuditLogModels;
using AdvanceSolutionSample.Context;
using AdvanceSolutionSample.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AdvanceSolutionSample.Interceptors
{
    public class ProductHistoryInterceptor:SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if(eventData.Context is null)
            return base.SavingChanges(eventData, result);
            var auditContext = eventData.Context as AuditDbContext;
            var changeEntity = auditContext.ChangeTracker.Entries<Product>().FirstOrDefault();
            if (changeEntity == default)
                return base.SavingChanges(eventData,result);
            var history = new ProductHistory()
            {
                Name = changeEntity.Entity.Name,
                Price = changeEntity.Entity.Price,
                Description = changeEntity.Entity.Description
            };
            auditContext.Add(history);
            return base.SavingChanges(eventData, result);
        }
    }
}
