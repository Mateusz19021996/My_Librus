using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminActionsController : ControllerBase
    {
        private readonly MyLibrusDbContext _myLibrusDbContext;
        private readonly StudentSeeder _studentSeeder;

        public AdminActionsController(MyLibrusDbContext myLibrusDbContext, StudentSeeder studentSeeder)
        {
            _myLibrusDbContext = myLibrusDbContext;
            _studentSeeder = studentSeeder;
        }

        [HttpGet]
        public IActionResult GetAllData()
        {
            string sqlQuerry = "Select * from Students";
            var students = _myLibrusDbContext.Students.FromSqlRaw(sqlQuerry).ToList();

            return Ok(students);
        }

        [HttpDelete]
        public IActionResult DeleteAllData()
        {
            string sqlQuerry1 = "DELETE FROM [Students]";
            string sqlQuerry2 = "DELETE FROM [Grades]";
            string sqlQuerry3 = "DELETE FROM [Contact]";
            //TRUNCATE will throw exception that child tables are still exist. TRUNCATE is able to check it, DELETE no.
            _myLibrusDbContext.Students.FromSqlRaw(sqlQuerry1);
            _myLibrusDbContext.Grades.FromSqlRaw(sqlQuerry2);
            _myLibrusDbContext.Contact.FromSqlRaw(sqlQuerry3);
            _myLibrusDbContext.Database.ExecuteSqlRaw(sqlQuerry1);

            _myLibrusDbContext.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult SeedDataInSession()
        {
            var data = _studentSeeder.GetStudents();

            _myLibrusDbContext.Students.AddRange(data);

            _myLibrusDbContext.SaveChanges();

            return Ok();
        }
    } 
}
