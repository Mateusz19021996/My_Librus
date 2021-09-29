using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Controllers.Test_purpose
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MyLibrusDbContext _myLibrusDbContext;

        public ValuesController(MyLibrusDbContext myLibrusDbContext)
        {
            _myLibrusDbContext = myLibrusDbContext;
        }


        [HttpGet("Student")]
        public IActionResult Student([FromRoute] int x, [FromRoute] int y)
        {

            var value = x + y;

            return Ok(value);
        }

        [HttpGet("Teacher")]
        public IActionResult Teacher([FromRoute] int x, [FromRoute] int y)
        {

            var value = x + y;

            return Ok(value);
        }

        [HttpGet("Admin")]
        public IActionResult Admin([FromRoute] int x, [FromRoute] int y)
        {

            var value = x + y;

            return Ok(value);
        }
    }
}
