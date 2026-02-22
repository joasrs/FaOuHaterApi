using Dominio.Enum;

namespace Dominio.Interfaces.Base
{
    public interface IHttpResult
    {
        public IEnumerable<string> Messages { get; set; }
        public EnumHttpStatusCode GetStatusCode();
    }
}
