using Dominio.Entidades;

namespace Domain.Interfaces
{
    public interface IAuthService
    {
        string GerarToken(Usuario usuario);
        string Hash(string senha);
        bool ValidarSenha(string senha, string hash);
    }
}
