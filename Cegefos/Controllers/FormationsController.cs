using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cegefos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FormationsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "OK.";
        }
    }
}
