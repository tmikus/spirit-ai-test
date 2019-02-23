using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzPinkFlamingoController : ControllerBase
    {
        // GET api/fizzbuzzpinkflamingo/{endNumber}
        [HttpGet("{endNumber}")]
        public IActionResult Get(uint endNumber)
        {
            return Ok(new
            {
                lines = FizzBuzzPinkFlamingo.GenerateSequence(endNumber),
            });
        }

    }
}
