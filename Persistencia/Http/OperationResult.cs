using Dominio.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace Infra.Http
{
    public class OperationResult<TObject> : IOperationResult<TObject>
    {
        public TObject Data { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }

        public OperationResult(TObject data, string? message = null, Exception? exception = null)
        {
            Data = data;
            Message = message;
            Exception = exception;
        }   

        public  Task ExecuteResultAsync(ActionContext context)
        {
            throw new NotImplementedException();
        }

        public static IOperationResult<TObject> InvalidInput(string message)
        {
            throw new NotImplementedException();
        }

        //public abstract IActionResult Success(TObject obj)
        //{
        //    return new OkObjectResult(obj);
        //}

        //public  IActionResult InvalidInput(string message)
        //{
        //    return new BadRequestObjectResult(new { Error = message }); 
        //}

        //public  IActionResult NotFound(string message)
        //{
        //    return new NotFoundObjectResult(new { Error = message });
        //}

        //public  IActionResult Error(Exception ex)
        //{
        //    return new ObjectResult(new { Error = ex.Message }) { StatusCode = 500 };
        //}
    }
}
