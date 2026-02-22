using Dominio.Enum;
using Dominio.Interfaces.Base;

namespace Infra.Http
{
    public class HttpResult : IHttpResult
    {
        private readonly EnumHttpStatusCode _statusCode;
        public IEnumerable<string> Messages { get; set; } = new List<string>();

        public HttpResult(EnumHttpStatusCode statusCode, string? messagem = null)
        {
            _statusCode = statusCode;
            Messages = !string.IsNullOrEmpty(messagem) ? new List<string> { messagem } : new List<string>();
        }

        public HttpResult(EnumHttpStatusCode statusCode, IEnumerable<string> messages)
        {
            _statusCode = statusCode;
            Messages = (messages?.Count() ?? 0) > 0 ? messages! : new List<string>();
        }

        public HttpResult AddMessage(string message)
        {
            Messages.Append(message);
            return this;
        }

        public EnumHttpStatusCode GetStatusCode()
        {
            return _statusCode;
        }

        public static IHttpResult Ok()
        {
            return new HttpResult(EnumHttpStatusCode.Ok);
        }

        public static IHttpResult NotFound(string? message = null)
        {
            return new HttpResult(EnumHttpStatusCode.NotFound, message);
        }

        public static IHttpResult BadRequest(string? message = null)
        {
            return new HttpResult(EnumHttpStatusCode.BadRequest, message);
        }

        public static IHttpResult InternalServerError(Exception ex)
        {
            return new HttpResult(EnumHttpStatusCode.InternalServerError, ex.Message);
        }

        public static IHttpResult InvalidInput(string? message = null)
        {
            return new HttpResult(EnumHttpStatusCode.InvalidInput, message);
        }

        public static IHttpResult InvalidInput(IEnumerable<string> message)
        {
            return new HttpResult(EnumHttpStatusCode.InvalidInput, message);
        }

        public static IHttpResult Created()
        {
            return new HttpResult(EnumHttpStatusCode.Created);
        }

        public static IHttpResult CreateStatusCode(EnumHttpStatusCode statusCode, string? message = null)
        {
            return new HttpResult(statusCode, message);
        }
    }
}
