using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrus.Entities.DTO.GetDTO;
using MyLibrus.Services;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        private readonly MyLibrusDbContext _myLibrusDbContext;
        private readonly IMapper _mapper;

        public ClassController(IGradeService gradeService, IMapper mapper, MyLibrusDbContext myLibrusDbContext)
        {
            _gradeService = gradeService;
            _mapper = mapper;
            _myLibrusDbContext = myLibrusDbContext;
        }


        [HttpGet]
        public IActionResult GetAllClasses()
        {
            var students = _myLibrusDbContext
                .Students                
                .ToList();

            var listOfClasses = new List<string>();

            foreach (var item in students)
            {
                listOfClasses.Add(item.StudentClass);
            }

            var retList = listOfClasses.Distinct();

            return Ok(retList);    
        }

        [HttpGet("{nameOfClass}")]
        public IActionResult GetAllStudentsOfOneClass([FromRoute] string nameOfClass)
        {
            var students = _myLibrusDbContext
                .Students
                .Where(x => x.StudentClass == nameOfClass)
                .ToList();

            return Ok(students);
        }

        // all subjects for one, particular class

        [HttpGet("/subjects/{nameOfClass}")]
        public IActionResult GetAllSubjectsForClass([FromRoute] string nameOfClass)
        {
            //take all students of this class
            var students = _myLibrusDbContext
                .Students
                .Where(x => x.StudentClass == nameOfClass)
                .Select(x => x.Id)
                .ToList();

            List<string> subjects = new List<string>();

            foreach (var item in students)
            {
                var krotki = _myLibrusDbContext
                .Grades
                .FirstOrDefault(x => x.StudentId == item);

                subjects.Add(krotki.Subject);
            }

            var retList = subjects.Distinct().ToList();
            
            return Ok(retList);
        }

        [HttpGet("/subject/{nameOfClass}/{nameOfSubject}")]
        public IActionResult GetAllStudentsGradesForAllClass([FromRoute] string nameOfClass, [FromRoute] string nameOfSubject)
        {
            var students = _myLibrusDbContext
                .Students
                .Where(x => x.StudentClass == nameOfClass)
                .ToList();

            var generes = students.Select(x => x.Grades);

            List<GetGradesForAllClassFromSubject> listOfStudentsWithGrades = new List<GetGradesForAllClassFromSubject>();

            foreach (var item in students)
            {

                var studentGradesFromSubject = new GetGradesForAllClassFromSubject
                {
                    Name = item.Name,
                    Grades = new List<int>()
                };

                var studentsWithGrades = _myLibrusDbContext
                    .Grades
                    .Where(x => x.StudentId == item.Id && x.Subject == nameOfSubject)
                    .Select(x => x.SingleGrade)
                    .ToList();

                studentGradesFromSubject.Grades = studentsWithGrades;

                listOfStudentsWithGrades.Add(studentGradesFromSubject);
            };



            return Ok(listOfStudentsWithGrades);
        }




    }
}
