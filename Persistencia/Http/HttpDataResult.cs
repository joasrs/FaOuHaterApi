using Dominio.Enum;
using Dominio.Interfaces.Base;

namespace Infra.Http;

public class HttpDataResult<TData> : HttpResult, IHttpDataResult<TData>
{
    public TData? Data { get; set; }

    public HttpDataResult(EnumHttpStatusCode statusCode, TData? data = default, string? messagem = null) : base(statusCode, messagem)
    {
        Data = data;
    }

    public HttpDataResult(Exception ex) : base(ex)
    {
    }

    public static new IHttpDataResult<TData> InternalServerError(Exception ex) => new HttpDataResult<TData>(ex);
    public static IHttpDataResult<TData> Ok(TData data) => new HttpDataResult<TData>(EnumHttpStatusCode.Ok, data);
    public static new IHttpDataResult<TData> NotFound(string? message = null) => new HttpDataResult<TData>(EnumHttpStatusCode.NotFound, default, message);
    public static new IHttpDataResult<TData> BadRequest(string? message = null) => new HttpDataResult<TData>(EnumHttpStatusCode.BadRequest, default, message);
    public static new IHttpDataResult<TData> InvalidInput(string? message = null) => new HttpDataResult<TData>(EnumHttpStatusCode.InvalidInput, default, message);
    public static new IHttpDataResult<TData> CreateStatusCode(EnumHttpStatusCode statusCode, string? message = null) => new HttpDataResult<TData>(statusCode, default, message);
}
