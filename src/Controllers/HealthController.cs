using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cerberix.HealthCheck.Core;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : Controller
	{
        private readonly HealthCheckService _healthCheckService;

		public HealthController(
            HealthCheckService healthCheckService
			)
		{
            _healthCheckService = healthCheckService;
        }

        [HttpGet]
        public async Task<HealthCheckResult[]> HealthDetails()
        {
            var results = await _healthCheckService.GetResults();
            return results;
        }
    }
}