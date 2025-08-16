using Domain.Interfaces.Base;
using Dominio.Entidades.Base;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios.Base
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : EntidadeBase
    {
        private readonly DbFaOuHaterContext _context;
        public readonly DbSet<TEntidade> DbSet;

        public RepositorioBase(DbFaOuHaterContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntidade>();
        }

        public bool Add(TEntidade entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            return DbSet.Add(entity) != null;
        }

        public bool Delete(TEntidade entity)
        {
            return DbSet.Remove(entity) != null;
        }

        public TEntidade? Obter(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntidade> ObterTodos()
        {
            return DbSet;
        }

        public bool SalvarAlteracaoes()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(TEntidade entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            return DbSet.Update(entity) != null;
        }
    }
}
