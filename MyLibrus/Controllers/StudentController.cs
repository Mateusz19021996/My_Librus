using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
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
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
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
            
            var id = _studentService.CreateStudent(studentDto);
            

            return Created($"/api/Student/{id}", null); // second is information , not obligatory
        }
    }
}