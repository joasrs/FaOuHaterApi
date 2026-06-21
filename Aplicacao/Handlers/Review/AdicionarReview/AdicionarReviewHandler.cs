using Aplicacao.Validators.Review;
using Dominio.Interfaces;
using Dominio.Interfaces.Base;
using Infra.Http;
using MediatR;

namespace Aplicacao.Handlers.Review.AdicionarReview;

public class AdicionarReviewHandler(IUsuarioContext usuarioContext, IReviewRepositorio reviewRepositorio) : IRequestHandler<AdicionarReviewRequest, IHttpResult>
{
    public Task<IHttpResult> Handle(AdicionarReviewRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var review = new Dominio.Entidades.Review
            {
                IdTrack = request.IdTrack,
                Artista = request.Artista,
                Musica = request.Musica,
                Review1 = request.Review,
                UsuarioId = usuarioContext.Usuario!.Id
            };

            var resultadoValidacao = new AdicionarReviewValidator().Validate(review);

            if (!resultadoValidacao.IsValid)
                return Task.FromResult(HttpResult.InvalidInput(resultadoValidacao.Errors.Select(e => e.ErrorMessage)));

            reviewRepositorio.Add(review);
            reviewRepositorio.SalvarAlteracaoes();

            return Task.FromResult(HttpResult.Created());
        }
        catch (Exception ex)
        {
            return Task.FromResult(HttpResult.InternalServerError(ex));
        }
    }
}
