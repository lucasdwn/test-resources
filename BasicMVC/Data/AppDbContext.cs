using BasicMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Personagem> Personagens { get; set; }


    }
}
