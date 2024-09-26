using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebAPITests.ControllerTests
{
    public class RunningTotalControllerTests
    {
        [Fact]
        public void RunningTotal_ShouldReturnCorrectResult_AfterMultipleCalls()
        {
            // Given
            var controller = new RunningTotalController();

            // When
            var result1 = (OkObjectResult)controller.UpdateRunningTotal("4");
            var result2 = (OkObjectResult)controller.UpdateRunningTotal("2");
            var result3 = (OkObjectResult)controller.UpdateRunningTotal("5");
            var result4 = (OkObjectResult)controller.UpdateRunningTotal("7");
            var result5 = (OkObjectResult)controller.UpdateRunningTotal("1");

            // Then
            result1.Value!.ToString().Should().Be("4");
            result2.Value!.ToString().Should().Be("6");
            result3.Value!.ToString().Should().Be("11");
            result4.Value!.ToString().Should().Be("14");
            result5.Value!.ToString().Should().Be("13");
        }
    }
}