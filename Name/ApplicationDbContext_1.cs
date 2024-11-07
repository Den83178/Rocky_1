using Microsoft.EntityFrameworkCore;
using Rocky_1.Models;
using System.Diagnostics;

namespace Rocky_1.Name
{
    public class ApplicationDbContext_1 : DbContext
    {
        public ApplicationDbContext_1(DbContextOptions<ApplicationDbContext_1> options)
            : base(options)
        {
            
        }

        public DbSet<Category_1> Category_1 { get; set; }

        public DbSet<ApplicationType_1> ApplicationType_1 { get; set; }
    }
}
