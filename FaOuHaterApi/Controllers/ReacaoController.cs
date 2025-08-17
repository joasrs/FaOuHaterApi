using Microsoft.AspNetCore.Mvc;

namespace FaOuHaterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReacaoController : ControllerBase
    {
        // PUT api/<ReacaoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
