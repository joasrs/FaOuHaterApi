using Dominio.Entidades;
using Dominio.Interfaces;
using Infra.Context;
using Infra.Repositorios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Comentario.AdicionarComentario
{
    public class AdicionarComentarioHandler : IRequestHandler<AdicionarComentarioRequest, IActionResult>
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

        public Task<IActionResult> Handle(AdicionarComentarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(request.Comentario))
                    return Task.FromResult<IActionResult>(new BadRequestObjectResult("Comentário não pode ser vazio."));

                var review = _reviewRepositorio.Obter(request.IdReview);

                if(review == null)
                    return Task.FromResult<IActionResult>(new NotFoundObjectResult("Review não encontrada."));

                _comentarioRepositorio.Add(new Dominio.Entidades.Comentario
                {
                    Comentario1 = request.Comentario,
                    IdOrigem = review.Id,
                    ReviewId = review.Id,
                    TipoOrigem = "Review",
                    UsuarioId = _usuarioContext.Usuario.Id
                });

                _comentarioRepositorio.SalvarAlteracaoes();

                return Task.FromResult<IActionResult>(new OkResult());
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(new ObjectResult(new { Error = ex.Message }) { StatusCode = 500 });
            }
        }
    }
}
