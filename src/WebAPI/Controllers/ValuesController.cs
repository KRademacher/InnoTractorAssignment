using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet("values")]
        public IActionResult GetSumOfValues()
        {
            var values = Values();
            int sum = 0;

            foreach (var value in values)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (TryConvert(value, out int convertedValue))
                    {
                        sum += convertedValue;
                    }
                }
            }

            return Ok(sum.ToString());
        }

        private string?[] Values()
        {
            return new string?[]
            {
            "42",
            "1e3",
            "1.222",
            null,
            "-12"
            };
        }

        private static bool TryConvert(string value, out int result)
        {
            try
            {
                // Scientific notation
                if (value.Contains('e') || value.Contains('E'))
                {
                    // Since we can't use floating point data types, we can't use double.Parse()
                    // As such, we extract the exponent and use it to calculate the power
                    var parts = value.Split('e', 'E');
                    int baseValue = int.Parse(parts[0]);
                    int exponent = int.Parse(parts[1]);

                    result = baseValue * (int)Math.Pow(10, exponent);
                    return true;
                }
                // Decimals
                else if (value.Contains('.'))
                {
                    value = value.Replace(".", "");
                    result = int.Parse(value);
                    return true;
                }
                // Everything else
                else
                {
                    result = int.Parse(value);
                    return true;
                }
            }
            catch
            {
                result = 0;
                return false;
            }
        }
    }
}