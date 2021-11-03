using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrus.Entities.DTO;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Controllers.Test_purpose
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaginationController : ControllerBase
    {
        private readonly MyLibrusDbContext _myLibrusDbContext;
        private readonly IMapper _mapper;

        public PaginationController(MyLibrusDbContext myLibrusDbContext, IMapper mapper)
        {
            _myLibrusDbContext = myLibrusDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllStudents([FromQuery] string searchPhrase)
        {
            var students = _myLibrusDbContext
                .Students
                .Include(x => x.Contact)
                .Include(x => x.Grades)
                .Where(x =>
                // jesli tutaj searchPhrase bedzie na null to automatycznie zwroci wszystkie rezultaty
                searchPhrase == null ||
               (x.Name.ToLower().Contains(searchPhrase.ToLower()) ||
                x.LastName.ToLower().Contains(searchPhrase.ToLower())))
                //.Where(x => x.Name.ToLower() == searchPhrase.ToLower() || x.LastName.ToLower() == searchPhrase.ToLower())
                .ToList();

            Console.WriteLine("xd");

            var studentsDto = _mapper.Map<List<StudentDTO>>(students);

            return Ok(studentsDto);
        }
    }
}
