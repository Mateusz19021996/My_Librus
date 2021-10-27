using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PasswordHashed { get; set; }

        public string Mail { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string TeacherMainSubject { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}