using Microsoft.EntityFrameworkCore;
using ProtoEF.Models;

namespace ProtoEF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Jobtype> Jobtypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vessel>()
                .Property(t => t.VesselName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Port>()
                .Property(t => t.PortCode)
                .HasMaxLength(5)
                .IsRequired();

            modelBuilder.Entity<Port>()
                .Property(t => t.PortName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Port>()
                .Property(t => t.PortType)
                .HasMaxLength(1)
                .HasColumnType("char")
                .IsRequired();

            modelBuilder.Entity<Party>()
                .Property(t => t.Name)
                .HasMaxLength(100);
            modelBuilder.Entity<Party>()
                .Property(t => t.Address)
                .HasMaxLength(500);
            modelBuilder.Entity<Party>()
                .Property(t => t.Phone)
                .HasMaxLength(100);
            modelBuilder.Entity<Party>()
                .Property(t => t.Fax)
                .HasMaxLength(100);
            modelBuilder.Entity<Party>()
                .Property(t => t.Email)
                .HasMaxLength(100);
            modelBuilder.Entity<Party>()
                .Property(t => t.AccountCode)
                .HasMaxLength(50);
            modelBuilder.Entity<Party>()
                .Property(t => t.CustomsCode)
                .HasMaxLength(50);
            modelBuilder.Entity<Party>()
                .Property(t => t.TaxNo)
                .HasMaxLength(50);

            modelBuilder.Entity<PaymentTerm>()
                .Property(t => t.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<Country>()
                .Property(t => t.CountryCode)
                .HasMaxLength(2);
            modelBuilder.Entity<Country>()
                .Property(t => t.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<Jobtype>()
                .Property(t => t.JobType)
                .HasMaxLength(10);

            modelBuilder.Entity<Jobtype>()
                .Property(t => t.JobYear)
                .HasMaxLength(4);


            modelBuilder.Entity<Jobtype>()
                .HasKey(t => new { t.JobType, t.JobYear });


            modelBuilder.Entity<Jobtype>()
                .Property(t => t.JobPrefix)
                .HasMaxLength(10);

            modelBuilder.Entity<Jobtype>()
                .Property(t => t.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Jobtype>()
                .Property(t => t.CostCenter)
                .HasMaxLength(10);

        }
    }
}