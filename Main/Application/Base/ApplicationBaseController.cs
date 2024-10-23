﻿using Main.Application.DendencyInjection;
using Main.Application.Factory;
using Main.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Main.Application.Base
{
    public abstract class ApplicationBaseController<T> : ControllerBase where T : class
    {
        protected readonly ILogger<T> _logger;
        protected readonly IBusinessHandlersFactory _businessHandlers;

        public ApplicationBaseController(IControllerDependencies<T> dependencies)
        {
            _logger = dependencies.Logger;
            _businessHandlers = dependencies.BusinessHandlers;
        }
    }
}
