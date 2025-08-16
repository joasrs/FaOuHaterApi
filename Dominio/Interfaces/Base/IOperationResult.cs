using Microsoft.AspNetCore.Mvc;

namespace Dominio.Interfaces.Base
{
    public interface IOperationResult<TObject>
    {
        static IActionResult Success(TObject obj)
        {
            return new OkObjectResult(obj);
        }
        //static IActionResult InvalidInput(string message)
        //{
        //    return new BadRequestObjectResult(new { Error = message });
        //}
        //IActionResult InvalidInput(string message);
        //IActionResult NotFound(string message);
        //IActionResult Error(Exception ex);
    }
}
