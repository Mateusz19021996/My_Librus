using MyLibrus.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities
{
    public class TestStudent: User
    {
        public string StudentClass { get; set; }

        public List<Grade> Grades { get; set; }
    }
}
