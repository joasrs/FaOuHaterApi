using FaOuHaterApi.Interfaces.Base;
using FaOuHaterApi.Models;
using FaOuHaterApi.Models.DTOs.Review;
using Microsoft.AspNetCore.Mvc;

namespace FaOuHaterApi.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
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
