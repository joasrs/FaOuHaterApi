namespace FaOuHaterApi.Interfaces.Base
{
    public interface IServiceBase<RequisicaoDto, RespostaDto>
    {
        public IEnumerable<RespostaDto> Get();
        public RespostaDto Get( int id );
        public RespostaDto Post( RequisicaoDto target );
    }
}
