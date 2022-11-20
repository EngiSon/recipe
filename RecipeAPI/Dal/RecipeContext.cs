using Microsoft.EntityFrameworkCore;
using RecipeAPI.Models;

namespace RecipeAPI.Dal
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options) { }

        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasKey(x => x.Id);
            modelBuilder.Entity<User>()
            .Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Recipe>()
            .HasKey(x => x.Id);
            modelBuilder.Entity<Recipe>()
            .Property(x => x.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
