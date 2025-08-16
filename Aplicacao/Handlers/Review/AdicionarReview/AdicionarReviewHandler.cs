using Aplicacao.Validators.Review;
using Dominio.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Review.AdicionarReview
{
    public class AdicionarReviewHandler : IRequestHandler<AdicionarReviewRequest, IActionResult>
    {
        public readonly IUsuarioContext _usuarioContext;
        public readonly IReviewRepositorio _reviewRepositorio;

        public AdicionarReviewHandler(IUsuarioContext usuarioContext, IReviewRepositorio reviewRepositorio)
        {
            _usuarioContext = usuarioContext;
            _reviewRepositorio = reviewRepositorio;
        }

        public Task<IActionResult> Handle(AdicionarReviewRequest request, CancellationToken cancellationToken)
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
                    return Task.FromResult<IActionResult>(new BadRequestObjectResult(resultadoValidacao.Errors.Select(e => e.ErrorMessage)));

                _reviewRepositorio.Add(review);
                _reviewRepositorio.SalvarAlteracaoes();

                return Task.FromResult<IActionResult>(new OkResult());
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(new ObjectResult(new { Error = ex.Message }) { StatusCode = 500 });
            }
        }
    }
}
