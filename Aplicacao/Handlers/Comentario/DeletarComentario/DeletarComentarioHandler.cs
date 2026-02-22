using Dominio.Interfaces;
using Dominio.Interfaces.Base;
using Infra.Http;
using MediatR;

namespace Aplicacao.Handlers.Comentario.DeletarComentario
{
    public class DeletarComentarioHandler : IRequestHandler<DeletarComentarioRequest, IHttpResult>
    {
        private readonly IComentarioRepositorio _comentarioRepositorio;

        public DeletarComentarioHandler(IComentarioRepositorio comentarioRepositorio)
        {
            _comentarioRepositorio = comentarioRepositorio;
        }

        public Task<IHttpResult> Handle(DeletarComentarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.IdComentario <= 0)
                    return Task.FromResult(HttpResult.InvalidInput("Necessário informar o Id do comentário"));

                var review = _comentarioRepositorio.Obter(request.IdComentario);

                if (review == null)
                    return Task.FromResult(HttpResult.NotFound("Não foi encontrado nenhum comentário com o Id informado"));

                _comentarioRepositorio.Delete(review);
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
