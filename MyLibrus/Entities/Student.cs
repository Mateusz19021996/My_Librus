using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities
{
    public class Student
    {
        public int Id { get; set; }
        // to know, what user is this particular student
        //public int UserId { get; set; }

        [MaxLength(10)]
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string StudentClass { get; set; }        

        public virtual Contact Contact { get; set; }

        public List<Grade> Grades { get; set; }
    }
}
