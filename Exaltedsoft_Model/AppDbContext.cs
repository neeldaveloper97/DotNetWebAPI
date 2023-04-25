using Exaltedsoft_Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exaltedsoft_Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }

        public DbSet<Adaptations> Adaptations { get; set; }
        public DbSet<ThemeColors> ThemeColors { get; set; }
        public DbSet<FontStyles> FontStyles { get; set; }
    }
}
