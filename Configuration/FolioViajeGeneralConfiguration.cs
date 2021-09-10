using LinkOracle.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Configuration
{
    public class FolioViajeGeneralConfiguration : IEntityTypeConfiguration<FolioViajeGeneral>
    {
        public void Configure(EntityTypeBuilder<FolioViajeGeneral> builder)
        {
            builder.HasKey(e => e.ClaveFolioViaje);

            builder.ToTable("FolioViajeGeneral_OTM","SAE");

            builder.Property(e => e.ClaveFolioViaje)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FolioViaje)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Operador)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Placa)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Ruta)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.SalidaProgramada).HasColumnType("date");

            builder.Property(e => e.Unidad)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
