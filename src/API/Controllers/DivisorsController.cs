using API.Responses;
using Application;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/divisors")]
    public class DivisorsController : ControllerBase
    {
        [HttpGet("{number}")]
        public IActionResult GetDivisors(int number)
        {
            if (number <= 0)
            {
                return BadRequest(new { ErrorMessage = "Number should be a natural number different than 0" });
            }

            var divisors = MathFunctions.GetDivisors(number);
            var primeDivisors = divisors.Where(divisor => MathFunctions.IsPrime(divisor));

            var response = new GetDivisorsResponse(divisors, primeDivisors);

            return Ok(response);
        }
    }
}