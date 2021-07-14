﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities.DTO
{
    public class StudentDTO
    {
        public string Name { get; set; }

        public int Age { get; set; }
        
        public string Mail { get; set; }

        public List<GradeDTO> Grades { get; set; }
    }
}