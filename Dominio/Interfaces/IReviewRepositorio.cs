using Domain.Interfaces.Base;
using Dominio.Dtos.Review;
using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IReviewRepositorio : IRepositorioBase<Review>
    {
        IEnumerable<ReviewRespostaDto> ObterReviews(int idUsuario);
    }
}
