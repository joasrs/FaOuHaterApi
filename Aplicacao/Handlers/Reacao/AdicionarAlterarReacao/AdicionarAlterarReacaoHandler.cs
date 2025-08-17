using Dominio.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Reacao.AdicionarAlterarReacao
{
    public class AdicionarAlterarReacaoHandler : IRequestHandler<AdicionarAlterarReacaoRequest, IActionResult>
    {
        private readonly IUsuarioContext _usuarioContext;
        private readonly IReacaoRepositorio _reacaoRepositorio;
        private readonly IReviewRepositorio _reviewRepositorio;

        public AdicionarAlterarReacaoHandler(IUsuarioContext usuarioContext, IReacaoRepositorio reacaoRepositorio, IReviewRepositorio reviewRepositorio)
        {
            _usuarioContext = usuarioContext;
            _reacaoRepositorio = reacaoRepositorio;
            _reviewRepositorio = reviewRepositorio;
        }

        public Task<IActionResult> Handle(AdicionarAlterarReacaoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.IdReview <= 0)
                    return Task.FromResult<IActionResult>(new BadRequestObjectResult("Necessário informar o Id da review."));

                if(!_reviewRepositorio.Existe(request.IdReview))
                    return Task.FromResult<IActionResult>(new BadRequestObjectResult("Não foi encontrado nenhuma review com o id especificado."));

                Dominio.Entidades.Reacao? reacao = _reacaoRepositorio.ObterReacaoPorUsuarioReview(_usuarioContext.Usuario.Id, request.IdReview);

                if(reacao != null)
                {
                    reacao.TipoReacao = request.TipoReacao;
                    _reacaoRepositorio.Update(reacao);
                }
                else
                {
                    reacao = new Dominio.Entidades.Reacao
                    {
                        ReviewId = request.IdReview,
                        UsuarioId = _usuarioContext.Usuario.Id,
                        TipoReacao = request.TipoReacao
                    };

                    _reacaoRepositorio.Add(reacao);
                }

                _reacaoRepositorio.SalvarAlteracaoes();

                return Task.FromResult<IActionResult>(new OkResult());
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(new ObjectResult(new { Error = ex.Message }) { StatusCode = 500 });
            }
        }
    }
}
