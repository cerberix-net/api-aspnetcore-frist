using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]", Name = "Config")]
    public class ConfigController : Controller
	{
        [HttpGet]
		public IActionResult Get()
		{
			var result = new
			{
				Application = "Api",
				Properties = new
				{
					Utils.ApiConfigurationProperties.Instance.AssemblyName,
                    Utils.ApiConfigurationProperties.Instance.Version,
                    Utils.ApiConfigurationProperties.Instance.BuildHash,
                    Utils.ApiConfigurationProperties.Instance.BuildDate
				},
				Info = new
				{
					Config = Url.RouteUrl("Config", null, Request.Scheme),
				}
			};

			return Ok(result);
		}
	}
}