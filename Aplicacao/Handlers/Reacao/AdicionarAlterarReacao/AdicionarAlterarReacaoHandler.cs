using Dominio.Interfaces;
using Dominio.Interfaces.Base;
using Infra.Http;
using MediatR;

namespace Aplicacao.Handlers.Reacao.AdicionarAlterarReacao;

public class AdicionarAlterarReacaoHandler : IRequestHandler<AdicionarAlterarReacaoRequest, IHttpResult>
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

    public Task<IHttpResult> Handle(AdicionarAlterarReacaoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.IdReview <= 0)
                return Task.FromResult(HttpResult.InvalidInput("Necessário informar o Id da review."));

            if(!_reviewRepositorio.Existe(request.IdReview))
                return Task.FromResult(HttpResult.NotFound("Não foi encontrado nenhuma review com o id especificado."));

            var reacao = _reacaoRepositorio.ObterReacaoPorUsuarioReview(_usuarioContext.Usuario.Id, request.IdReview);

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

            return Task.FromResult(HttpResult.Ok());
        }
        catch (Exception ex)
        {
            return Task.FromResult(HttpResult.InternalServerError(ex));
        }
    }
}
