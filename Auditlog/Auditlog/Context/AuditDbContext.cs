using AdvanceSolutionSample.AuditLogModels;
using AdvanceSolutionSample.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvanceSolutionSample.Context
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        #region AuditLog
        public DbSet<ProductHistory> ProductHistories { get; set; }
        #endregion
    }
}
