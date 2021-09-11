using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities.DTO
{
    public class CreateGradeDTO
    {
        public int SingleGrade { get; set; }

        public string Subject { get; set; }
        
        public int StudentId { get; set; }
    }
}
