using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO.CreateDTO;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MyLibrusDbContext _myLibrusDbContext;
        private readonly IPasswordHasher<User> _hasher;

        public AccountController(MyLibrusDbContext myLibrusDbContext, IPasswordHasher<User> hasher)
        {
            _myLibrusDbContext = myLibrusDbContext;
            _hasher = hasher;
        }

        [HttpPost]
        public void CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var user = new User
            {
                FirstName = createUserDTO.FirstName,
                LastName = createUserDTO.LastName,
                Mail = createUserDTO.Mail,
                RoleId = createUserDTO.RoleId
            };

            // here we hash our password, which comes from DTO
            var passwordAfterHashed = _hasher.HashPassword(user, createUserDTO.Password);
            // here we assign this password to orginal user entity
            user.PasswordHashed = passwordAfterHashed;

            _myLibrusDbContext.Users.Add(user);
            _myLibrusDbContext.SaveChanges();
        }
    }
}
