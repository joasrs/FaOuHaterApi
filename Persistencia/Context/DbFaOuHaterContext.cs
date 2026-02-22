using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context;

public partial class DbFaOuHaterContext : DbContext
{
    public DbFaOuHaterContext()
    {
    }

    public DbFaOuHaterContext( DbContextOptions<DbFaOuHaterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Reacao> Reacoes { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Comentarios_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentario1).HasColumnName("comentario");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasColumnType("timestamptz");
            entity.Property(e => e.IdOrigem).HasColumnName("idOrigem");
            entity.Property(e => e.ReviewId ).HasColumnName( "ReviewId" );
            entity.Property(e => e.TipoOrigem)
                .HasMaxLength(255)
                .HasColumnName("tipoOrigem");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt").HasColumnType("timestamptz").IsRequired(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Comentarios_UsuarioId_fkey");
        });

        modelBuilder.Entity<Reacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Reacoes_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasColumnType("timestamptz");
            entity.Property(e => e.Dislike).HasColumnName("dislike");
            entity.Property(e => e.Like).HasColumnName("like");
            entity.Property(e => e.TipoReacao).HasColumnName("tipoReacao").HasColumnType("smallint");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt").HasColumnType("timestamptz").IsRequired(false);

            entity.HasOne(d => d.Review).WithMany(p => p.Reacoes)
                .HasForeignKey(d => d.ReviewId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Reacoes_ReviewId_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reacoes )
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Reacoes_UsuarioId_fkey");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Reviews_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Artista)
                .HasMaxLength(255)
                .HasColumnName("artista");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasColumnType("timestamptz");
            entity.Property(e => e.Dislike).HasColumnName("dislike");
            entity.Property(e => e.Like).HasColumnName("like");
            entity.Property(e => e.Musica)
                .HasMaxLength(255)
                .HasColumnName("musica");
            entity.Property(e => e.Review1).HasColumnName("review");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt").HasColumnType("timestamptz").IsRequired(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Reviews_UsuarioId_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Usuarios_pkey");

            entity.HasIndex(e => e.Email, "Usuarios_email_key").IsUnique();

            entity.HasIndex(e => e.Login, "Usuarios_login_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Admin).HasColumnName("admin");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt").HasColumnType("timestamptz");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .HasColumnName("senha");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt").HasColumnType("timestamptz").IsRequired(false);
            entity.Property(e => e.UrlImagemPerfil)
                .HasColumnType("character varying")
                .HasColumnName("urlImagemPerfil");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
