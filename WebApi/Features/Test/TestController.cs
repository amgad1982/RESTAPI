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
    public class TestController:ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator){
            this._mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _mediator.Send(new Index.Query());
            return Ok(response);
        }
    }
}
