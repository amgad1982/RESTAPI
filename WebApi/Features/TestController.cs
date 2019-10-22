using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Features
{
    [Route("api/test")]
    public class TestController:ControllerBase
    {
        [HttpGet]
        public IActionResult GetTestData()
        {
            return Ok(new { Result="this is response"});
        }
    }
}
