using Domain.Interfaces.Base;
using Dominio.Entidades;

namespace Domain.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        bool VerificarUsuarioExiste(string login, string email);
        Usuario? ObterPorLogin(string login);
    }
}
