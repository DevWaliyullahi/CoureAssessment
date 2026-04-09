using CoureAssessment.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CoureAssessment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreController : ControllerBase
    {
        [HttpPost]
        public IActionResult Calculate([FromBody] int[] numbers)
        {
            var result = ScoreCalculator.CalculateScore(numbers);
            return Ok(result);
        }
    }
}
