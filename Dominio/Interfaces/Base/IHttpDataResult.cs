namespace Dominio.Interfaces.Base
{
    public interface IHttpDataResult<TData> : IHttpResult
    {
        public TData? Data { get; set; }
    }
}
