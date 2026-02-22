using Aplicacao.Validators.Review;
using Dominio.Interfaces;
using Dominio.Interfaces.Base;
using Infra.Http;
using MediatR;

namespace Aplicacao.Handlers.Review.AdicionarReview
{
    public class AdicionarReviewHandler : IRequestHandler<AdicionarReviewRequest, IHttpResult>
    {
        public readonly IUsuarioContext _usuarioContext;
        public readonly IReviewRepositorio _reviewRepositorio;

        public AdicionarReviewHandler(IUsuarioContext usuarioContext, IReviewRepositorio reviewRepositorio)
        {
            _usuarioContext = usuarioContext;
            _reviewRepositorio = reviewRepositorio;
        }

        public Task<IHttpResult> Handle(AdicionarReviewRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var review = new Dominio.Entidades.Review
                {
                    Artista = request.Artista,
                    Musica = request.Musica,
                    Review1 = request.Review,
                    UsuarioId = _usuarioContext.Usuario.Id
                };

                var resultadoValidacao = new AdicionarReviewValidator().Validate(review);

                if (!resultadoValidacao.IsValid)
                    return Task.FromResult(HttpResult.InvalidInput(resultadoValidacao.Errors.Select(e => e.ErrorMessage)));

                _reviewRepositorio.Add(review);
                _reviewRepositorio.SalvarAlteracaoes();

                return Task.FromResult(HttpResult.Created());
            }
            catch (Exception ex)
            {
                return Task.FromResult(HttpResult.InternalServerError(ex));
            }
        }
    }
}
