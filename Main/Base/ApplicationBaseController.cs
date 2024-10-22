using Main.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Main.Base
{
    public class ApplicationBaseController : ControllerBase
    {
        protected readonly ILogger<WeatherForecastController> _logger;
        protected readonly IBusinessServicesFactory _businessServices;

        public ApplicationBaseController(ILogger<WeatherForecastController> logger, IBusinessServicesFactory businessServices)
        {
            _logger = logger;
            _businessServices = businessServices;
        }
    }
}
