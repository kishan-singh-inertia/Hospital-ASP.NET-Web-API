using Microsoft.EntityFrameworkCore;

namespace Hospital.Models
{
    public class DonationDbContext : DbContext
    {
        public DonationDbContext(DbContextOptions<DonationDbContext> options)
            : base(options)
        {
        }

        // Tables
        public DbSet<District> Districts { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Donation> Donations { get; set; }

        
    }
}