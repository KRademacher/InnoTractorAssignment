using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        [HttpGet("fizzbuzz")]
        public IActionResult GetFizzBuzz()
        {
            var result = new List<FizzBuzz>();

            for (int i = 0; i <= 30; i++)
            {
                string output;

                // First check if divisible by both
                if (i % 3 == 0 && i % 5 == 0)
                    output = "FizzBuzz";
                // If not, then check if divisible by 3
                else if (i % 3 == 0)
                    output = "Fizz";
                // If not, then check if divisble by 5
                else if (i % 5 == 0)
                    output = "Buzz";
                // If not, return number in string format
                else
                    output = i.ToString();

                result.Add(new (i, output));
            }

            return Ok(result);
        }
    }
}
