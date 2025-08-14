using Domain.Interfaces.Base;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios.Base
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : class
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
            return DbSet.Add(entity) != null;
        }

        public bool Delete(int id)
        {
            return DbSet.Remove(Obter(id)) != null;
        }

        public TEntidade Obter(int id)
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
            return DbSet.Update(entity) != null;
        }
    }
}
