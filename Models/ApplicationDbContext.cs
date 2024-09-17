using IV.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace IV.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<MotivationalQuote> MotivationalQuotes { get; set; }
        public DbSet<CalorieCalculation> CalorieCalculations { get; set; }
        public DbSet<InspirationalVideo> InspirationalVideos { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<User>()
                .HasMany(u => u.MotivationalQuotes)
                .WithOne(q => q.User)
                .HasForeignKey(q => q.UserID);

            /*modelBuilder.Entity<User>()
                .HasMany(u => u.CalorieCalculations)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserID);*/

            modelBuilder.Entity<User>()
                .HasMany(u => u.InspirationalVideos)
                .WithOne(v => v.User)
                .HasForeignKey(v => v.UserID);
        }
    }
}