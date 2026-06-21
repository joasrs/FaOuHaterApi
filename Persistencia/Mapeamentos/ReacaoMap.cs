using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos;

public class ReacaoMap : IEntityTypeConfiguration<Reacao>
{
    public void Configure(EntityTypeBuilder<Reacao> builder)
    {
        builder.ToTable("Reacoes");
        builder.HasKey(e => e.Id).HasName("Reacoes_pkey");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.CreatedAt).HasColumnName("createdAt").HasColumnType("timestamptz");
        builder.Property(e => e.Dislike).HasColumnName("dislike");
        builder.Property(e => e.Like).HasColumnName("like");
        builder.Property(e => e.TipoReacao).HasColumnName("tipoReacao").HasColumnType("smallint");
        builder.Property(e => e.UpdatedAt).HasColumnName("updatedAt").HasColumnType("timestamptz").IsRequired(false);
        
        builder.HasOne(d => d.Review).WithMany(p => p.Reacoes).HasForeignKey(d => d.ReviewId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("Reacoes_ReviewId_fkey");

        builder.HasOne(d => d.Usuario).WithMany(p => p.Reacoes).HasForeignKey(d => d.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("Reacoes_UsuarioId_fkey");
    }
}
