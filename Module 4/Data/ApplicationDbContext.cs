using Microsoft.EntityFrameworkCore;
using Module_4.Models.Entities;

namespace Module_4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
            
}
