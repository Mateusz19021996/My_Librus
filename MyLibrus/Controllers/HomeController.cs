using Microsoft.AspNetCore.Mvc;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly MyLibrusDbContext _myLibrusDbContext;

        public HomeController(MyLibrusDbContext myLibrusDbContext)
        {

        }
    }
}
