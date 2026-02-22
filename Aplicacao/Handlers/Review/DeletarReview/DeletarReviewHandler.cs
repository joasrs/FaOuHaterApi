using Dominio.Interfaces;
using Dominio.Interfaces.Base;
using Infra.Http;
using MediatR;

namespace Aplicacao.Handlers.Review.DeletarReview
{
    public class DeletarReviewHandler : IRequestHandler<DeletarReviewRequest, IHttpResult>
    {
        public readonly IReviewRepositorio _reviewRepositorio;

        public DeletarReviewHandler(IUsuarioContext usuarioContext, IReviewRepositorio reviewRepositorio)
        {
            _reviewRepositorio = reviewRepositorio;
        }

        public Task<IHttpResult> Handle(DeletarReviewRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if(request.IdReview <= 0)
                    return Task.FromResult(HttpResult.InvalidInput("Necessário informar o Id da review"));

                var review = _reviewRepositorio.Obter(request.IdReview);

                if (review == null)
                    return Task.FromResult(HttpResult.NotFound("Não foi encontrado nenhuma review com o Id informado"));

                _reviewRepositorio.Delete(review);
                _reviewRepositorio.SalvarAlteracaoes();

                return Task.FromResult(HttpResult.Ok());
            }
            catch (Exception ex)
            {
                return Task.FromResult(HttpResult.InternalServerError(ex));
            }
        }
    }
}
