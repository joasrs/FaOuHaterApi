using Domain.Interfaces.Base;
using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IComentarioRepositorio : IRepositorioBase<Comentario>
    {
        IEnumerable<Comentario> ObterComentariosPorReview(int idReview);
    }
}
