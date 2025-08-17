using Dominio.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Handlers.Reacao.AdicionarAlterarReacao
{
    public class AdicionarAlterarReacaoRequest : IRequest<IActionResult>
    {
        public int IdReview { get; set; }
        public EnumTipoReacao TipoReacao { get; set; } = EnumTipoReacao.Indefinido;
    }
}
