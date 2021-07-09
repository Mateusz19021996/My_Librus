using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
using MyLibrus.Entities.DTO.EditDTO;
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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentService.GetStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent([FromRoute] int id)
        {
            var student = _studentService.GetStudent(id);
            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] CreateStudentDTO studentDto)
        {
            _studentService.CreateStudent(studentDto);

            return Created("Created new student", null); // second is information , not obligatory
        }

        [HttpPatch("{id}")]
        public IActionResult EditStudent([FromBody] EditStudentDTO editStudentDto, [FromRoute] int id)
        {
            var isOk = _studentService.EditStudent(editStudentDto, id);

            if (isOk)
            {
                return Ok("Student created successfully");
            }
            else
            {
                return BadRequest("Student doesn't exist");
            }
            
        }

    }
}