using System;
using api.RomanCalculator;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RomanCalculatorController : ControllerBase
    {
        // GET api/romancalculator?input=
        [HttpGet]
        public ActionResult<string> Get([FromQuery(Name = "input")] string input)
        {
            try
            {
                return Ok(new
                {
                    output = Calculator.Evaluate(input),
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
