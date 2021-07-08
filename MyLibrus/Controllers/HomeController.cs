using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrus.Entities;
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

        [HttpPost]
        public IActionResult Create([FromBody] CreateStudentDTO createStudentDTO)
        {
            // mapujemy DTO na encje student 

            var student = _mapper.Map<Student>(createStudentDTO);


            _myLibrusDbContext.Students.Add(student);
            _myLibrusDbContext.SaveChanges();

            return Created($"/api/Student/{student.Id}", null);

        }

        [HttpPost("{id}")]
        public IActionResult CreateGrade([FromBody] CreateGradeDTO createGradeDTO, [FromRoute] int id)
        {
            var grade = _mapper.Map<Grade>(createGradeDTO);

            grade.StudentId = id;

            _myLibrusDbContext.Grades.Add(grade);
            _myLibrusDbContext.SaveChanges();

            return Ok();
        }
    }
}
