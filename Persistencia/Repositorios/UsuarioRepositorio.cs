using Dominio.Entidades;
using Domain.Interfaces;
using Infra.Repositorios.Base;
using Infra.Context;

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
