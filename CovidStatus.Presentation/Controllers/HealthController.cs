using Microsoft.AspNetCore.Mvc;
using CovidStatus.Presentation.Interfaces;
using CovidStatus.Presentation.Model;

namespace CovidStatus.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IHealthService _healthService;

        public HealthController(IHealthService healthService)
        {
            _healthService = healthService;
        }

        [HttpGet("GetCovidResults")]
        public Covid GetCovidResults()
        {
            return _healthService.GetCovidResults();
        }
    }
}
