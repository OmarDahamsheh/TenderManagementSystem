using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tender> Tenders { get; set; } = null!;
        public DbSet<EligibilityCriteria> EligibilityCriterias { get; set; } = null!;
        public DbSet<TenderDocument> TenderDocuments { get; set; } = null!;
        public DbSet<Bid> Bids { get; set; } = null!;
        public DbSet<BidDocument> BidDocuments { get; set; } = null!;
        public DbSet<FinancialProposal> FinancialProposals { get; set; } = null!;
        public DbSet<TechnicalProposal> TechnicalProposals { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                 .HasIndex(u=>u.Email).IsUnique();

            modelBuilder.Entity<TenderDocument>()
                 .HasIndex(d => d.TenderId);

            modelBuilder.Entity<TenderDocument>()
                 .HasIndex(d => d.TenderId);

            modelBuilder.Entity<EligibilityCriteria>()
                 .HasIndex(e => e.TenderId);


            modelBuilder.Entity<Tender>()
                .HasOne(t => t.CreatedByUser)
                .WithMany(u => u.CreatedTenders)
                .HasForeignKey(t => t.CreatedByUserId);

            modelBuilder.Entity<Tender>()
                .HasMany(t=>t.EligibilityCriteria)
                .WithOne(e=>e.Tender)
                .HasForeignKey(e => e.TenderId);

            modelBuilder.Entity<Tender>()
                .HasMany(t=>t.TenderDocument)
                .WithOne(d=>d.Tender)
                .HasForeignKey(d => d.TenderId);

            modelBuilder.Entity<Tender>()
                .HasMany(t=>t.Bids)
                .WithOne(b => b.Tender)
                .HasForeignKey(b => b.TenderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Bid>()
               .HasMany(b => b.BidDocuments)
               .WithOne(d => d.Bid)
               .HasForeignKey(b => b.BidId);

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bids)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Bid>()
                .HasMany(b=>b.FinancialProposal)
                .WithOne(f => f.Bid)
                .HasForeignKey(f => f.BidId); 
            
            modelBuilder.Entity<Bid>()
                .HasMany(b=>b.TechnicalProposal)
                .WithOne(t => t.Bid)
                .HasForeignKey(t => t.BidId); 
        }
    }

   
}
