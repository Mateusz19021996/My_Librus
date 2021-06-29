﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrus.Entities;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MyLibrusDbContext _myLibrusDbContext;
        private readonly IMapper _mapper;

        public StudentController(MyLibrusDbContext myLibrusDbContext, IMapper mapper)
        {
            _myLibrusDbContext = myLibrusDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var students = _myLibrusDbContext
                .Students
                .Include(x => x.Contact)
                .Include(y => y.Grades)
                .ToList();

            return Ok(students);
        }


        [HttpGet("{id}")]
        public IActionResult GetStudent([FromRoute] int id)
        {
            var student = _myLibrusDbContext
                .Students
                //if no exist will be null
                .FirstOrDefault(r => r.Id == id);

            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        //[HttpPost]
        //public IActionResult CreateStudent([FromBody] CreateStudentDto dto) 
        //{
        //    var student = _mapper.Map<Student>(dto);
        //    _myLibrusDbContext.Students.Add(student);
        //    _myLibrusDbContext.SaveChanges();

        //    return Ok();
        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<StudentDto>> getAll2()
        //{
        //    var students = _myLibrusDbContext
        //        .Students
        //        .ToList();

        //    // without automapper
        //    var studentsDto = students.Select(x => new StudentDto()
        //    {
        //        Name = x.Name,
        //        Age = x.Age
        //    });

        //    // with automapper 
        //    return Ok(students);
        // }
        

    }
}
