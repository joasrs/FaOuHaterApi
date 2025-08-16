using Dominio.Dtos.Review;
using Dominio.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Review.ObterReviews
{
    public class ObterReviewsHandler : IRequestHandler<ObterReviewsRequest, ActionResult<IEnumerable<ReviewRespostaDto>>>
    {
        private readonly IUsuarioContext _usuarioContext;
        private readonly IReviewRepositorio _reviewRepositorio;

        public ObterReviewsHandler(IUsuarioContext usuarioContext, IReviewRepositorio reviewRepositorio)
        {
            _usuarioContext = usuarioContext;
            _reviewRepositorio = reviewRepositorio;
        }

        public Task<ActionResult<IEnumerable<ReviewRespostaDto>>> Handle(ObterReviewsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = _reviewRepositorio.ObterReviews(_usuarioContext.Usuario.Id);

                return Task.FromResult<ActionResult<IEnumerable<ReviewRespostaDto>>>(new OkObjectResult(response));
            }
            catch (Exception ex)
            {
                return Task.FromResult<ActionResult<IEnumerable<ReviewRespostaDto>>>(new ObjectResult(new { Error = ex.Message }) { StatusCode = 500 });
            }
        }
    }
}
