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
    //if we have grade which is depending on students we need to give below way
    //api/student/{student.id}/dish
    [Route("api/{studentId}/grade")] // if we have {studentId}, if we add st[FromRoute] studentId to our values, ASP will automaticly knows that it is the same
    [ApiController]

    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;

        public GradesController(IGradeService gradeService, IMapper mapper)
        {
            _gradeService = gradeService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetAllGradesForStudent([FromRoute] int id)
        {
            var grades = _gradeService.GetAllGrades(id);

            return Ok(grades);
        }
    } 
}
