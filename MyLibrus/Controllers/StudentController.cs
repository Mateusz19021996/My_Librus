using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize(Roles = "Student")]
        //[Authorize]
        public IActionResult GetAll([FromQuery] UserPaginationParameters userPaginationParameters)
        {
            var studentsDto = _studentService.GetStudents();

            //Response.AddPagination

            return Ok(studentsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent([FromRoute] int id)
        {
            var studentDto = _studentService.GetStudent(id);
            //if not exist - null
            return Ok(studentDto);
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

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var check = _studentService.DeleteStudent(id);

            if (check)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Source was not deleted");
            }
        }

    }
}