using Domain.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;
using Infra.Context;
using Infra.Repositorios.Base;

namespace Infra.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DbFaOuHaterContext context) : base(context)
        {
        }

        public Usuario? ObterPorLogin(string login)
        {
            return DbSet.FirstOrDefault(u => u.Login == login);
        }

        public bool VerificarUsuarioExiste(string login, string email)
        {
            return DbSet.Any(u => u.Login == login || u.Email == email);
        }
    }
}
