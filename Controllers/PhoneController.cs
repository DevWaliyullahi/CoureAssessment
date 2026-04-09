using CoureAssessment.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoureAssessment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _service;

        public PhoneController(IPhoneService service)
        {
            _service = service;
        }

        [HttpGet("{phoneNumber}")]
        public IActionResult Get(string phoneNumber)
        {
            var result = _service.GetCountryByPhone(phoneNumber);
            return result == null ? NotFound(new { error = "Country not found" }) : Ok(result);
        }
    }
}
