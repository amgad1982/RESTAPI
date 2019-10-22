using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Features.Test;

namespace WebApi.Features.Test
{
    [Route("api/test")]
    public class TestController:FeatureController
    {
        public TestController(IMediator mediator) : base(mediator) { }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await this.mediator.Send(new Index.Query());
            return Ok(response);
        }
    }
}
