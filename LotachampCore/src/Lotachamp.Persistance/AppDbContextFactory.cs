using Microsoft.EntityFrameworkCore;
using Lotachamp.Persistance;
using Lotachamp.Persistence.Infrastructure;

namespace Lotachamp.Persistence
{
    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options);
        }
    }
}
