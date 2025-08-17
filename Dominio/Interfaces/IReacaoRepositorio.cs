using Domain.Interfaces.Base;
using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IReacaoRepositorio : IRepositorioBase<Reacao>
    {
        Reacao? ObterReacaoPorUsuarioReview(int idUsuario, int idReview);
    }
}
