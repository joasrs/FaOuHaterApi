using Dominio.Entidades;

namespace Dominio.Interfaces;

public interface IAuthService
{
    string GerarToken(Usuario usuario);
    string Hash(string senha);
    bool ValidarSenha(string senha, string hash);
}
