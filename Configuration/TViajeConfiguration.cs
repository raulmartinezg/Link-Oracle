using LinkOracle.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkOracle.Configuration
{
    public class TViajeConfiguration : IEntityTypeConfiguration<TbmaeViaje>
    {
        public void Configure(EntityTypeBuilder<TbmaeViaje> builder)
        {
            builder.HasKey(e => e.ClaveViaje)
                    .HasName("PK_Viaje");

            builder.ToTable("TBMAE_Viaje");

            builder.Property(e => e.ClaveViaje)
                .HasColumnName("ClaveViaje");

            builder.Property(e => e.ClaveEstatus)
                .HasColumnName("ClaveEstatus");

            builder.Property(e => e.ClaveUsuario)
                .HasColumnName("ClaveUsuario");

            builder.Property(e => e.EstatusCro)
                .HasColumnName("EstatusCro")
                .HasColumnType("bigint");

            builder.Property(e => e.ClaveFolioViaje)
                .HasColumnName("ClaveFolioViaje");

            builder.Property(e => e.Unidad)
                .HasColumnName("Unidad");

            builder.Property(e => e.FechaEstatus).HasColumnType("datetime");

            builder.Property(e => e.FolioViaje).HasMaxLength(50);

            builder.Property(e => e.Host).HasMaxLength(50);

            builder.Property(e => e.Operador).HasMaxLength(150);

            builder.Property(e => e.Placa).HasMaxLength(50);

            builder.Property(e => e.Ruta).HasMaxLength(150);

            builder.Property(e => e.SalidaProgramada).HasColumnType("datetime");
        }
    }
}
