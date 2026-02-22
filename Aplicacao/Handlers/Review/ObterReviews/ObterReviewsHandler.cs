using Dominio.Dtos.Review;
using Dominio.Interfaces;
using Dominio.Interfaces.Base;
using Infra.Http;
using MediatR;

namespace Aplicacao.Handlers.Review.ObterReviews;

public class ObterReviewsHandler : IRequestHandler<ObterReviewsRequest, IHttpDataResult<IEnumerable<ReviewRespostaDto>>>
{
    private readonly IUsuarioContext _usuarioContext;
    private readonly IReviewRepositorio _reviewRepositorio;

    public ObterReviewsHandler(IUsuarioContext usuarioContext, IReviewRepositorio reviewRepositorio)
    {
        _usuarioContext = usuarioContext;
        _reviewRepositorio = reviewRepositorio;
    }

    public Task<IHttpDataResult<IEnumerable<ReviewRespostaDto>>> Handle(ObterReviewsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            request.IdUsuarioAutenticado = _usuarioContext?.Usuario?.Id ?? 0;
            var response = _reviewRepositorio.ObterReviews(request);

            if ((response?.Count() ?? 0) == 0)
                return Task.FromResult(HttpDataResult<IEnumerable<ReviewRespostaDto>>.NotFound("Nenhuma review foi encontrada com o filtro informado."));

            return Task.FromResult(HttpDataResult<IEnumerable<ReviewRespostaDto>>.Ok(response!));
        }
        catch (Exception ex)
        {
            return Task.FromResult(HttpDataResult<IEnumerable<ReviewRespostaDto>>.InternalServerError(ex));
        }
    }
}
