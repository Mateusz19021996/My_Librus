using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities
{
    public class Grade
    { 
        public int Id { get; set; }        

        public int SingleGrade { get; set; }

        public string Subject { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

    }
}
