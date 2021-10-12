using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
using MyLibrus.Entities.DTO.GetDTO;
using MyLibrus.Services;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Controllers
{
    //if we have grade which is depending on students we need to give below way
    //api/student/{student.id}/dish
    [Route("api/grade")] // if we have {studentId}, if we add st[FromRoute] studentId to our values, ASP will automaticly knows that it is the same
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        private readonly MyLibrusDbContext _myLibrusDbContext;
        private readonly IMapper _mapper;

        public GradesController(IGradeService gradeService, IMapper mapper, MyLibrusDbContext myLibrusDbContext)
        {
            _gradeService = gradeService;
            _mapper = mapper;
            _myLibrusDbContext = myLibrusDbContext;
        }

        //[HttpGet]
        //public IActionResult GetAllGradesForStudent([FromRoute] int id)
        //{
        //    var grades = _gradeService.GetAllGrades(id);

        //    return Ok(grades);
        //}

        [HttpGet]
        //[Authorize]
        public IActionResult GetAll()
        {
            var grades = _myLibrusDbContext
                .Grades
                .ToList();

            return Ok(grades);
        }

//          select Subject, StudentId, Id, SingleGrade from grades
//          group by Subject, StudentId,Id,SingleGrade;

        [HttpGet("{id}")]
        public IActionResult GetAllGradesBySubject([FromRoute] int id)
        {
            // take all records for particular id student
            var grades = _myLibrusDbContext
                .Grades
                .Where(x => x.StudentId == id)               
                .ToList();
                  
            //this logic provide us all subjects, that this student has
            List<string> subjectss = new List<string>();

            foreach (var item in grades)
            {
                subjectss.Add(item.Subject);
            }

            //we distinct it, because above loop gives for example 3 chemist to list
            List<string> subjects = subjectss.Distinct().ToList();
            
            var lenghtOfSubjects = subjects.Count();
            
            List<GetSubjectWithGrades> returnList = new List<GetSubjectWithGrades>();                       
            List<int> studentgrades = new List<int>();

            //we iterate for particular subject 
            for (int i = 0; i < lenghtOfSubjects; i++)
            {
                // create object with one subject and grades for this object for particular student
                var check = new GetSubjectWithGrades()
                {
                    Subject = "",
                    Grades = new List<int>()
                };

                //every item in grades
                foreach (var item in grades)
                {
                    //which subject == "FirstSubject" ; assign subject ; assing grades to list
                    if(item.Subject == subjects[i])
                    {
                        check.Subject = item.Subject;
                        check.Grades.Add(item.SingleGrade);
                    }
                }
                //we add this object to list
                returnList.Add(check);

            }
            //return
            return Ok(returnList);
        }

        [HttpGet("/users")]
        public IActionResult GetAllu()
        {
            var grades = _myLibrusDbContext
                .Users
                .ToList();

            return Ok(grades);
        }

        [HttpGet("/roles")]
        public IActionResult GetAllr()
        {
            var grades = _myLibrusDbContext
                .Roles
                .ToList();

            return Ok(grades);
        }
    } 
}
