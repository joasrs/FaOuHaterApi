using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos;

public class ReviewMap : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");
        builder.HasKey(e => e.Id).HasName("Reviews_pkey");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.IdTrack).HasColumnName("idTrack");
        builder.Property(e => e.Artista).HasMaxLength(255).HasColumnName("artista");
        builder.Property(e => e.CreatedAt).HasColumnName("createdAt").HasColumnType("timestamptz");
        builder.Property(e => e.Dislike).HasColumnName("dislike");
        builder.Property(e => e.Like).HasColumnName("like");
        builder.Property(e => e.Musica).HasMaxLength(255).HasColumnName("musica");
        builder.Property(e => e.Review1).HasColumnName("review");
        builder.Property(e => e.UpdatedAt).HasColumnName("updatedAt").HasColumnType("timestamptz").IsRequired(false);

        builder.HasOne(d => d.Usuario).WithMany(p => p.Reviews).HasForeignKey(d => d.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("Reviews_UsuarioId_fkey");
    }
}
