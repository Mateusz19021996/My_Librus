using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities.DTO.CreateDTO
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public string TeacherMainSubject { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int RoleId { get; set; } = 1;
    }
}
