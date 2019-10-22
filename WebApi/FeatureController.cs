using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class FeatureController:ControllerBase
    {
        internal readonly IMediator mediator;
        public FeatureController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
