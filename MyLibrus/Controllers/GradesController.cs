using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    //if we have grade which is depending on students we need to give below way
    //api/student/{student.id}/dish
    [Route("api/{studentId}/grade")] // if we have {studentId}, if we add st[FromRoute] studentId to our values, ASP will automaticly knows that it is the same
    [ApiController]
   
    public class GradesController : ControllerBase
    {
        private readonly MyLibrusDbContext _myLibrusDbContext;
        private readonly IMapper _mapper;

        public GradesController(MyLibrusDbContext myLibrusDbContext, IMapper mapper)
        {
            _myLibrusDbContext = myLibrusDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllGrades([FromRoute] int studentId)
        {
            var student = _myLibrusDbContext
                .Students
                .Include(x => x.Grades)
                .FirstOrDefault(x => x.Id == studentId);

            var listOfGrades = _mapper.Map<List<GradeDTO>>(student.Grades);

            return Ok(listOfGrades);
        }

        [HttpPost]
        public IActionResult AddGrade([FromRoute] int studentId, [FromBody]CreateGradeDTO createGradeDTO)
        {
            var student = _myLibrusDbContext.Students.FirstOrDefault(x => x.Id == studentId);

            if (student == null)
            {
                // WYWALI wyjatek notFoundException
            }

            var grade = _mapper.Map<Grade>(createGradeDTO);

            grade.StudentId = studentId;

            _myLibrusDbContext.Add(grade);
            _myLibrusDbContext.SaveChanges();

            return Ok();
        }    
        
        //this method does not have sense, it's just for test purpose
        [HttpGet("{gradeId}")]
        public IActionResult Get([FromRoute] int studentId, [FromRoute] int gradeId)
        {
            //szukamy konkretnej oceny dla konkretnego klienta, troche bez sensu, tylko do testow
            var student = _myLibrusDbContext
                .Students
                .Include(x => x.Grades)
                .FirstOrDefault(x => x.Id == studentId);

            var gradeDto = student.Grades.FirstOrDefault(x => x.Id == gradeId);

            return Ok(gradeDto);
        }        
    }
}
