using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities.DTO
{
    public class CreateStudentDTO
    {        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Range(1,6)]
        public int Age { get; set; }

        public string Street { get; set; }
        [EmailAddress]
        public string Mail { get; set; } 

    }
}
