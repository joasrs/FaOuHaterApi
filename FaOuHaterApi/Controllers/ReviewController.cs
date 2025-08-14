using Dominio.Dtos.Review;
using Dominio.Interfaces.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaOuHaterApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        IServiceBase<ReviewRequisicaoDto, ReviewRespostaDto> _reviewService;

        public ReviewController( IServiceBase<ReviewRequisicaoDto, ReviewRespostaDto> reviewService )
        {
            _reviewService = reviewService;
        }

        [HttpGet( Name = "GetReviews" )]
        public IEnumerable<ReviewRespostaDto> Get()
        {
            return _reviewService.Get();
        }
    }
}
