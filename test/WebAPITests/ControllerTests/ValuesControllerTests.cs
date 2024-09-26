using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebAPITests.ControllerTests
{
    public class ValuesControllerTests
    {
        [Fact]
        public void GetSumOfValues_ShouldReturnCorrectSum()
        {
            // Given
            var controller = new ValuesController();

            // When
            var result = (OkObjectResult)controller.GetSumOfValues();

            // Then
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            result.Value.Should().NotBeNull();

            var sum = int.Parse(result.Value!.ToString()!);
            sum.Should().Be(2252);
        }
    }
}