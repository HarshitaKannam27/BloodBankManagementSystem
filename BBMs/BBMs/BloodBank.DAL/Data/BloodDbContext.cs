using BloodBank.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.DAL.Data
{
    public class BloodDbContext : DbContext
    {
        public BloodDbContext(DbContextOptions<BloodDbContext> options) : base(options)
        {

        }

        public DbSet<BloodBankCenter> BloodBankCenters { get; set; }
        public DbSet<BloodBag> BloodBags { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationships between entities
            modelBuilder.Entity<Donor>()
            .HasOne(d => d.BloodBankCenter)
            .WithMany()
            .HasForeignKey(d => d.BloodBankId);

            modelBuilder.Entity<Recipient>()
           .HasOne(r => r.BloodBankCenter)
           .WithMany()
           .HasForeignKey(r => r.BloodBankId);

            modelBuilder.Entity<BloodBag>()
           .HasOne(b => b.BloodBankCenter)
           .WithMany()
           .HasForeignKey(b => b.BloodBankId)
           .OnDelete(DeleteBehavior.NoAction);


            object value = modelBuilder.Entity<BloodBag>()
            .HasOne(b => b.Donor)
            .WithMany()
            .HasForeignKey(b => b.DonorId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
