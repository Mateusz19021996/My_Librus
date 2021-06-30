using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrus.Entities.DTO;
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
        private readonly IMapper _mapper;

        public HomeController(MyLibrusDbContext myLibrusDbContext, IMapper mapper)
        {
            _myLibrusDbContext = myLibrusDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var students = _myLibrusDbContext
                .Students
                .Include(x => x.Grades)
                //.Include(y => y.Contact)
                .ToList();

            var studentsDtos = _mapper.Map<List<StudentDTO>>(students);

            //var studentDtos = students.Select(x => new StudentDTO
            //{
            //    Name = x.Name,
            //    Age = x.Age,
            //    Mail = x.Contact.Mail,
            //    Grades = x.Grades
            //});

            return Ok(studentsDtos);
        }
    }
}
