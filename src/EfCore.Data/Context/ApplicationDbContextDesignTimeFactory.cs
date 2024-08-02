
using Microsoft.EntityFrameworkCore.Design;

namespace EfCore.Data.Context
{
    public class ApplicationDbContextDesignTimeFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var context = new ApplicationDbContext();
            return context;
        }
    }
}
