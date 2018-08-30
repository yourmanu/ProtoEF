using Microsoft.EntityFrameworkCore;
using ProtoEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoEF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<Port> Ports { get; set; }

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


        }

    }
}
