﻿using Main.Application.DendencyInjection;
using Main.Application.Factory;

namespace Main.Application.Base
{
    public interface IBaseBusinessHandler
    {
        public string TestBaseBusinessHandler();
    }

    public abstract class BaseBusinessHandler : IBaseBusinessHandler
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseBusinessHandler(IBusinessHandlerDependencies businessHandlerDependencies)
        {
            _unitOfWork = businessHandlerDependencies.UnitOfWork;
        }

        public string TestBaseBusinessHandler()
        {
            return "TestBaseBusinessHandler";
        }
    }
}
