using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CovidStatus.Presentation.Interfaces;
using CovidStatus.Presentation.Model;

namespace CovidStatus.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;
        private readonly IHealthService _healthService;

        public HealthController(ILogger<HealthController> logger, IHealthService healthService)
        {
            _logger = logger;
            _healthService = healthService;
        }

        [HttpGet("GetCovidResults")]
        public Covid GetCovidResults()
        {
            return _healthService.GetCovidResults();
        }
    }
}
