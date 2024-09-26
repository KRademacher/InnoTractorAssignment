using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using WebAPI.Models;

namespace WebAPITests.ControllerTests
{
    public class FizzBuzzControllerTests
    {
        [Fact]
        public void GetFizzBuzz_ShouldReturnCorrectResult()
        {
            // Given
            var controller = new FizzBuzzController();

            // When
            var result = (OkObjectResult)controller.GetFizzBuzz();
            var values = (List<FizzBuzz>)result.Value!;

            // Then
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            values.Should().NotBeNull();

            int fizzCount = 0, buzzCount = 0, fizzBuzzCount = 0;

            foreach (var item in values)
            {
                if (item.Output == "Fizz")
                    fizzCount++;
                else if (item.Output == "Buzz")
                    buzzCount++;
                else if (item.Output == "FizzBuzz")
                    fizzBuzzCount++;
            }

            fizzCount.Should().Be(8);
            buzzCount.Should().Be(4);
            fizzBuzzCount.Should().Be(3);
        }
    }
}