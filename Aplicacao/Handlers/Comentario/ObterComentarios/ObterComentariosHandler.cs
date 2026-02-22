using Dominio.Interfaces;
using Dominio.Interfaces.Base;
using Infra.Http;
using MediatR;

namespace Aplicacao.Handlers.Comentario.ObterComentarios
{
    public class ObterComentariosHandler : IRequestHandler<ObterComentariosRequest, IHttpDataResult<IEnumerable<ObterComentariosResponse>>>
    {
        private readonly IComentarioRepositorio _comentarioRepositorio;

        public ObterComentariosHandler(IComentarioRepositorio comentarioRepositorio)
        {
            _comentarioRepositorio = comentarioRepositorio;
        }

        public Task<IHttpDataResult<IEnumerable<ObterComentariosResponse>>> Handle(ObterComentariosRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var comentarios = request.IdReview > 0 ? 
                                _comentarioRepositorio.ObterComentariosPorReview(request.IdReview) :
                                _comentarioRepositorio.ObterTodos();

                if ((comentarios?.Count() ?? 0) == 0)
                    return Task.FromResult(HttpDataResult<IEnumerable<ObterComentariosResponse>>.NotFound("Nenhum comentário encontrado."));

                var response = comentarios!.Select(c => new ObterComentariosResponse
                {
                    Comentario = c.Comentario1 ?? string.Empty
                });

                return Task.FromResult(HttpDataResult<IEnumerable<ObterComentariosResponse>>.Ok(response));
            }
            catch (Exception ex)
            {
                return Task.FromResult(HttpDataResult<IEnumerable<ObterComentariosResponse>>.InternalServerError(ex));
            }
        }
    }
}
