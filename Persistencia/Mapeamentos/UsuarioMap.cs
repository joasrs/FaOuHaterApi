using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamentos;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");
        builder.HasKey(e => e.Id).HasName("Usuarios_pkey");

        builder.HasIndex(e => e.Email, "Usuarios_email_key").IsUnique();
        builder.HasIndex(e => e.Login, "Usuarios_login_key").IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Admin).HasColumnName("admin");
        builder.Property(e => e.CreatedAt).HasColumnName("createdAt").HasColumnType("timestamptz");
        builder.Property(e => e.Email).HasMaxLength(255).HasColumnName("email");

        builder.Property(e => e.Login).HasMaxLength(255).HasColumnName("login");
        builder.Property(e => e.Nome).HasMaxLength(255).HasColumnName("nome");
        builder.Property(e => e.Senha).HasMaxLength(255).HasColumnName("senha");
        builder.Property(e => e.UpdatedAt).HasColumnName("updatedAt").HasColumnType("timestamptz").IsRequired(false);
        builder.Property(e => e.UrlImagemPerfil).HasColumnType("character varying").HasColumnName("urlImagemPerfil");
    }
}
