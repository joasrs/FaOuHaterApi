using Aplicacao.Handlers.Track.ObterTrack;
using Aplicacao.Validators.Review;
using Dominio.Interfaces;
using Dominio.Interfaces.Base;
using Infra.Http;
using MediatR;

namespace Aplicacao.Handlers.Review.AdicionarReview;

public class AdicionarReviewHandler(
    IMediator mediator,
    IUsuarioContext usuarioContext, 
    IReviewRepositorio reviewRepositorio
) : IRequestHandler<AdicionarReviewRequest, IHttpResult>
{
    public async Task<IHttpResult> Handle(AdicionarReviewRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var resultadoValidacao = new AdicionarReviewValidator().Validate(request);

            if (!resultadoValidacao.IsValid)
                return await Task.FromResult(HttpResult.InvalidInput(resultadoValidacao.Errors.Select(e => e.ErrorMessage)));

            var obterTrackResult = await mediator.Send(new ObterTrackRequest(request.IdTrack, request.Musica, request.Artista), cancellationToken);

            if (obterTrackResult?.Data == null)
                return await Task.FromResult(HttpResult.NotFound("Track não encontrada."));

            var review = new Dominio.Entidades.Review
            {
                IdTrack = obterTrackResult.Data.IdTrack,
                Artista = obterTrackResult.Data?.Artist ?? string.Empty,
                Musica = obterTrackResult.Data?.Name ?? string.Empty,
                Descricao = request.Descricao,
                Usuario = usuarioContext.Usuario!,
                ImagemUrl = obterTrackResult.Data?.ImageUrl ?? string.Empty
            };

            reviewRepositorio.Add(review);
            reviewRepositorio.SaveChanges();

            return await Task.FromResult(HttpResult.Created());
        }
        catch (Exception ex)
        {
            return await Task.FromResult(HttpResult.InternalServerError(ex));
        }
    }
}
