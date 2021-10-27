using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO.CreateDTO;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrus.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MyLibrusDbContext _myLibrusDbContext;
        private readonly IPasswordHasher<User> _hasher;
        private readonly AuthenticationSettins _authenticationSettins;

        public AccountController(MyLibrusDbContext myLibrusDbContext, IPasswordHasher<User> hasher, AuthenticationSettins authenticationSettings)
        {
            _myLibrusDbContext = myLibrusDbContext;
            _hasher = hasher;
            _authenticationSettins = authenticationSettings;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            //this logic has to be move into service
            var user = _myLibrusDbContext.Users
                .Include(x => x.Role)
                .FirstOrDefault(x => x.Mail == loginDTO.Email);


            // logic if user exist

            //check if password is okey 
            var result = _hasher.VerifyHashedPassword(user, user.PasswordHashed, loginDTO.Password);
            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadHttpRequestException("Bad password or username");
            }

            var claims = new List<Claim>()
            {
                //revocation versions of claims
                //new Claim("id", ClaimTypes.NameIdentifier, user.Id.ToString()),
                //new Claim("fullName", ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                //new Claim("role", ClaimTypes.Role, $"{user.Role.RoleName}"),

                new Claim("id", user.Id.ToString()),
                new Claim("fullName",  $"{user.FirstName} {user.LastName}"),
                new Claim("role", $"{user.Role.RoleName}"),
                new Claim("email", user.Mail.ToString()),
            };

            // jesli user podal podczas logowania, to jest, jesli nie to bedzie pusta
            if (!string.IsNullOrEmpty(user.TeacherMainSubject))
            {
                claims.Add(new Claim("TeacherMainSubject", user.TeacherMainSubject));                    
            }

            //here we generate private key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettins.JwtKey));
            //here we generate credencials
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //here we generate expires time of token
            var expires = DateTime.Now.AddDays(_authenticationSettins.JwtExpireDays);
            // issuer, audience( clients of api)
            var token = new JwtSecurityToken(
                _authenticationSettins.JwtIssuer,
                _authenticationSettins.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { Token = tokenHandler });
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

        [HttpGet("/returnRole/{id}")]
        public IActionResult getRole([FromRoute] int id)
        {
            var role = _myLibrusDbContext
                .Users
                .FirstOrDefault(x => x.Id == id);

            var roleId = role.RoleId;

            return Ok(roleId);            
        }

    }
}
