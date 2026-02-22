using Dominio.Enum;
using Dominio.Interfaces.Base;
using MediatR;

namespace Aplicacao.Handlers.Reacao.AdicionarAlterarReacao
{
    public class AdicionarAlterarReacaoRequest : IRequest<IHttpResult>
    {
        public int IdReview { get; set; }
        public EnumTipoReacao TipoReacao { get; set; } = EnumTipoReacao.Indefinido;
    }
}
