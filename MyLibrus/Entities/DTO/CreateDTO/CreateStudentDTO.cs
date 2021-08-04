using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities.DTO
{
    public class CreateStudentDTO
    {
        // validation in class CreateStudentValidation

        //[Required]
        //[MaxLength(30)]
        public string Name { get; set; }

        //[Required]
        //[MaxLength(30)]
        public string LastName { get; set; }

        //[Required]
        //[Range(1,6)]
        public int Age { get; set; }

        //[Required]
        //[MaxLength(30)]
        public string Street { get; set; }

        //[Required]
        //[EmailAddress]
        public string Mail { get; set; } 


    }
}
