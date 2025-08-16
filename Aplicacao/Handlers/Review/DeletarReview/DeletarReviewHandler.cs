using Dominio.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Review.DeletarReview
{
    public class DeletarReviewHandler : IRequestHandler<DeletarReviewRequest, IActionResult>
    {
        public readonly IReviewRepositorio _reviewRepositorio;

        public DeletarReviewHandler(IUsuarioContext usuarioContext, IReviewRepositorio reviewRepositorio)
        {
            _reviewRepositorio = reviewRepositorio;
        }

        public Task<IActionResult> Handle(DeletarReviewRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if(request.IdReview <= 0)
                    return Task.FromResult<IActionResult>(new BadRequestObjectResult("Necessário informar o Id da review"));

                var review = _reviewRepositorio.Obter(request.IdReview);

                if (review == null)
                    return Task.FromResult<IActionResult>(new BadRequestObjectResult("Não foi encontrado nenhuma review com o Id informado"));

                _reviewRepositorio.Delete(review);
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
