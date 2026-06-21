using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos;

public class ComentarioMap : IEntityTypeConfiguration<Comentario>
{
    public void Configure(EntityTypeBuilder<Comentario> builder)
    {
        builder.ToTable("Comentarios");
        builder.HasKey(e => e.Id).HasName("Comentarios_pkey");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Comentario1).HasColumnName("comentario");
        builder.Property(e => e.CreatedAt).HasColumnName("createdAt").HasColumnType("timestamptz");
        builder.Property(e => e.IdOrigem).HasColumnName("idOrigem");
        builder.Property(e => e.ReviewId).HasColumnName("ReviewId");
        builder.Property(e => e.TipoOrigem).HasMaxLength(255).HasColumnName("tipoOrigem");
        builder.Property(e => e.UpdatedAt).HasColumnName("updatedAt").HasColumnType("timestamptz").IsRequired(false);

        builder.HasOne(d => d.Usuario).WithMany(p => p.Comentarios).HasForeignKey(d => d.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("Comentarios_UsuarioId_fkey");
    }
}
