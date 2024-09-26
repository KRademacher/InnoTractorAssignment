using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RunningTotalController : ControllerBase
    {
        private static readonly Queue<int> _numbers = new();
        private const int MaxNumbersInQueue = 3;

        [HttpPut("runningtotal")]
        public IActionResult UpdateRunningTotal([FromBody] string input)
        {
            if (int.TryParse(input, out int number))
            {
                // Remove first number of queue if it exceeds max
                if (_numbers.Count >= MaxNumbersInQueue)
                {
                    _numbers.Dequeue();
                }

                // Enqueue latest number and calculate sum
                _numbers.Enqueue(number);
                var sum = _numbers.Sum();

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input.");
        }
    }
}