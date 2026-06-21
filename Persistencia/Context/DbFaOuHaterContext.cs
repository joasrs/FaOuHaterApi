using Infra.Mapeamentos;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ReviewMap());
        modelBuilder.ApplyConfiguration(new ComentarioMap());
        modelBuilder.ApplyConfiguration(new ReacaoMap());
        modelBuilder.ApplyConfiguration(new UsuarioMap());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
