using Dominio.Enum;
using Dominio.Interfaces.Base;
using System.Diagnostics;

namespace Infra.Http;

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

    public HttpResult(Exception ex)
    {
        _statusCode = EnumHttpStatusCode.InternalServerError;
        Messages = new List<string> { "Ocorreu um erro internamente." };

        try
        {
            Trace.TraceError(ex.ToString());
        }
        catch { }
    }

    public HttpResult AddMessage(string message)
    {
        Messages.ToList().Add(message);
        return this;
    }

    public int GetStatusCode() => (int)_statusCode;

    public static IHttpResult Ok() => new HttpResult(EnumHttpStatusCode.Ok);
    public static IHttpResult InternalServerError(Exception ex) => new HttpResult(ex);
    public static IHttpResult Created() => new HttpResult(EnumHttpStatusCode.Created);
    public static IHttpResult NotFound(string? message = null) => new HttpResult(EnumHttpStatusCode.NotFound, message);
    public static IHttpResult BadRequest(string? message = null) => new HttpResult(EnumHttpStatusCode.BadRequest, message);
    public static IHttpResult InvalidInput(string? message = null) => new HttpResult(EnumHttpStatusCode.InvalidInput, message);
    public static IHttpResult InvalidInput(IEnumerable<string> message) => new HttpResult(EnumHttpStatusCode.InvalidInput, message);
    public static IHttpResult CreateStatusCode(EnumHttpStatusCode statusCode, string? message = null) => new HttpResult(statusCode, message);
}
