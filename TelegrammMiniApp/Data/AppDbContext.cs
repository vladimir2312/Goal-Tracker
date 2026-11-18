using Microsoft.EntityFrameworkCore;
using TelegrammMiniApp.Models;

namespace TelegrammMiniApp.Data
    
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Goal> Goals { get; set; }
    }
}
