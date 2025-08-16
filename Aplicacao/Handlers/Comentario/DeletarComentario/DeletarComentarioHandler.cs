using Dominio.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Comentario.DeletarComentario
{
    public class DeletarComentarioHandler : IRequestHandler<DeletarComentarioRequest, IActionResult>
    {
        private readonly IComentarioRepositorio _comentarioRepositorio;

        public DeletarComentarioHandler(IComentarioRepositorio comentarioRepositorio)
        {
            _comentarioRepositorio = comentarioRepositorio;
        }

        public Task<IActionResult> Handle(DeletarComentarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.IdComentario <= 0)
                    return Task.FromResult<IActionResult>(new BadRequestObjectResult("Necessário informar o Id do comentário"));

                var review = _comentarioRepositorio.Obter(request.IdComentario);

                if (review == null)
                    return Task.FromResult<IActionResult>(new BadRequestObjectResult("Não foi encontrado nenhum comentário com o Id informado"));

                _comentarioRepositorio.Delete(review);
                _comentarioRepositorio.SalvarAlteracaoes();

                return Task.FromResult<IActionResult> (new OkResult());
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(new ObjectResult(new { Error = ex.Message }) { StatusCode = 500 });
            }
        }
    }
}
