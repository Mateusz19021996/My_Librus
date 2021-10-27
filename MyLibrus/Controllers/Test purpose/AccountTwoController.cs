using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO.CreateDTO;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyLibrus.Controllers.Test_purpose
{

    public interface IAccountTwoService
    {

    }

    [Route("api/[controller]")]
    [ApiController]
    public class AccountTwoController : ControllerBase
    {

        private readonly MyLibrusDbContext _myLibrusDbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountTwoController(MyLibrusDbContext myLibrusDbContext, IPasswordHasher<User> passwordHasher)
        {
            _myLibrusDbContext = myLibrusDbContext;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] CreateUserDTO createUserDTO)
        {

            //to powinno byc w serwisie, pamietac o wstrzyknieciu xd
            var newUser = new User()
            {
                Mail = createUserDTO.Mail,
                DateOfBirth = createUserDTO.DateOfBirth,
                TeacherMainSubject = createUserDTO.TeacherMainSubject,
                RoleId = createUserDTO.RoleId
            };

            //Funkcja haszująca jest jednokierunkowa, co oznacza, że z hasza już nie odzyskamy hasła
            //rejestracja IpasswordHasher :D
            var hashedPassword = _passwordHasher.HashPassword(newUser, createUserDTO.Password);

            newUser.PasswordHashed = hashedPassword;

            _myLibrusDbContext
                .Users
                .Add(newUser);

            _myLibrusDbContext
                .SaveChanges();

            return Ok();
        }

        // w appSettings.json dodajemy propertisy, dodajemy też klasę z tymi propertisami 

        //[HttpPost("login")]
        //public IActionResult Login([FromBody] LoginDTO login)
        //{
        //    //metoda do tworzenia JWT

        //    //sprawdzamy czy user istnieje

        //    var user = _myLibrusDbContext
        //        .Users
        //        .FirstOrDefault(x => x.Mail == login.Email);

        //    if(user is null)
        //    {
        //        // exception badRequestException , kod 400
        //    }

        //    //jesli user istnieje to czy podał dobre hasło
        //    var result = _passwordHasher
        //        .VerifyHashedPassword(user, user.PasswordHashed, login.Password);

        //    if(result == PasswordVerificationResult.Failed)
        //    {
        //        Console.WriteLine("exception ze złe hasło");
        //    }
        //    else
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        //        };
        //    }
        //}
    }
}
