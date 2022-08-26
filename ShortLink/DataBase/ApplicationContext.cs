using Microsoft.EntityFrameworkCore;
using ShortLink.Models;

namespace HelloApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Link> Links { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-P1B5G5I;Database=shortLink;Trusted_Connection=True;");
        }
    }
}