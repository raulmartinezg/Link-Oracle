using System;
using LinkOracle.Configuration;
using LinkOracle.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LinkOracle.Data
{
    public partial class SID_AutoCargaV3Context : DbContext
    {
        public SID_AutoCargaV3Context()
        {
        }

        public SID_AutoCargaV3Context(DbContextOptions<SID_AutoCargaV3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<FolioViajeGeneral> FolioViajeGenerals { get; set; }

        public virtual DbSet<TbmaeViaje> TbmaeViajes { get; set; }
        public virtual DbSet<TbmaeStop> TbmaeStop { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfiguration(new FolioViajeGeneralConfiguration());
            modelBuilder.ApplyConfiguration(new TViajeConfiguration());
            modelBuilder.ApplyConfiguration(new TStopConfiguration());
        }

    }
}
