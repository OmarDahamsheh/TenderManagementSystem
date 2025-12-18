using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tender> Tenders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u=>u.Email).IsUnique();

            modelBuilder.Entity<Tender>()
                .HasOne(t => t.CreatedByUser)
                .WithMany(u => u.CreatedTenders)
                .HasForeignKey(t => t.CreatedByUserId);

            modelBuilder.Entity<Tender>()
                .HasMany(t=>t.EligibilityCriteria)
                .WithOne(e=>e.Tender)
                .HasForeignKey(e => e.TenderId);

            
        }
    }

   
}
