using Dominio.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Comentario.ObterComentarios
{
    public class ObterComentariosHandler : IRequestHandler<ObterComentariosRequest, ActionResult<IEnumerable<ObterComentariosResponse>>>
    {
        private readonly IComentarioRepositorio _comentarioRepositorio;

        public ObterComentariosHandler(IComentarioRepositorio comentarioRepositorio)
        {
            _comentarioRepositorio = comentarioRepositorio;
        }

        public Task<ActionResult<IEnumerable<ObterComentariosResponse>>> Handle(ObterComentariosRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = request.IdReview > 0 ? 
                                _comentarioRepositorio.ObterComentariosPorReview(request.IdReview) :
                                _comentarioRepositorio.ObterTodos();

                return Task.FromResult<ActionResult<IEnumerable<ObterComentariosResponse>>>(new OkObjectResult(response));
            }
            catch (Exception ex)
            {
                return Task.FromResult<ActionResult<IEnumerable<ObterComentariosResponse>>>(new ObjectResult(new { Error = ex.Message }) { StatusCode = 500 });
            }
        }
    }
}
