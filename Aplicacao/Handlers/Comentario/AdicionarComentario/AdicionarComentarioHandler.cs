using Dominio.Interfaces;
using Dominio.Interfaces.Base;
using Infra.Http;
using MediatR;

namespace Aplicacao.Handlers.Comentario.AdicionarComentario
{
    public class AdicionarComentarioHandler : IRequestHandler<AdicionarComentarioRequest, IHttpResult>
    {
        private readonly IUsuarioContext _usuarioContext;
        private readonly IReviewRepositorio _reviewRepositorio;
        private readonly IComentarioRepositorio _comentarioRepositorio;

        public AdicionarComentarioHandler(IUsuarioContext usuarioContext, IReviewRepositorio reviewRepositorio, IComentarioRepositorio comentarioRepositorio)
        {
            _usuarioContext = usuarioContext;
            _reviewRepositorio = reviewRepositorio;
            _comentarioRepositorio = comentarioRepositorio;
        }

        public Task<IHttpResult> Handle(AdicionarComentarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(request.Comentario))
                    return Task.FromResult(HttpResult.InvalidInput("Comentário não pode ser vazio."));

                var review = _reviewRepositorio.Obter(request.IdReview);

                if(review == null)
                    return Task.FromResult(HttpResult.NotFound("Review não encontrada."));

                _comentarioRepositorio.Add(new Dominio.Entidades.Comentario
                {
                    Comentario1 = request.Comentario,
                    IdOrigem = review.Id,
                    ReviewId = review.Id,
                    TipoOrigem = "Review",
                    UsuarioId = _usuarioContext.Usuario.Id
                });

                _comentarioRepositorio.SalvarAlteracaoes();

                return Task.FromResult(HttpResult.Ok());
            }
            catch (Exception ex)
            {
                return Task.FromResult(HttpResult.InternalServerError(ex));
            }
        }
    }
}
