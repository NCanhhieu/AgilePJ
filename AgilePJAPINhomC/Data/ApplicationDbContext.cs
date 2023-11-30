using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AgilePJAPINhomC.Models;

namespace AgilePJAPINhomC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Userweb> Userweb { get; set; }

        public DbSet<Customer> customer { get; set; }
        public DbSet<Admin> admin { get; set; }

        public DbSet<Channel> Channel { get; set; }

        public DbSet<Clip> Clip { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<CategoryClip> categoryclip { get; set; }



    }
}

