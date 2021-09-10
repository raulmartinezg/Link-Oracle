using LinkOracle.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Configuration
{
    public class TStopConfiguration : IEntityTypeConfiguration<TbmaeStop>
    {
        public void Configure(EntityTypeBuilder<TbmaeStop> builder)
        {
            builder.HasKey(e => e.ClaveStop);

            builder.ToTable("TBMAE_Stop","SAE");

            builder.Property(e => e.ClaveStop)
                .HasColumnName("ClaveStop");

            builder.Property(e => e.ClaveViaje)
                .HasColumnName("ClaveViaje");

            builder.Property(e => e.ShipUnitId)
                .HasColumnName("ShipUnitId");

            builder.Property(e => e.Zone)
                .HasMaxLength(50)
                .HasColumnName("Zone");

            builder.Property(e => e.OrderRelease)
               .HasMaxLength(50)
               .HasColumnName("OrderRelease");

            builder.Property(e => e.EnRuta)
                .HasColumnName("EnRuta");
        }
    }
}
