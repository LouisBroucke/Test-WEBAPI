using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SterrenbeeldService.Repositories;

namespace SterrenbeeldService.Controllers
{
    [Route("api/sterrenbeelden")]
    [ApiController]
    public class SterrenbeeldController : ControllerBase
    {
        private readonly ISterrenRepository repository;
        private Regex regex = new Regex("^(0?[1-9]|[12][0-9]|3[01])[-](0?[1-9]|1[012])$");
        public SterrenbeeldController(ISterrenRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult FindByDagmaand(string dagmaand)
        {
            if (regex.IsMatch(dagmaand))
            {
                return base.Ok(repository.FindByDagmaand(dagmaand));
            }
            else
            {
                return base.BadRequest();
            }
            
        }
    }
}