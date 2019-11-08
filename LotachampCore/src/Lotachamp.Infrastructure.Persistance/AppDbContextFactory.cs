using Microsoft.EntityFrameworkCore;
using Lotachamp.Infrastructure.Persistance;
using Lotachamp.Infrastructure.Persistance.Infrastructure;

namespace Lotachamp.Infrastructure.Persistance
{
    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options);
        }
    }
}
