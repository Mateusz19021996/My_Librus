using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities.DTO.GetDTO
{
    public class GetGradesForAllClassFromSubject
    {
        public string Name { get; set; }

        public List<int> Grades { get; set; }
    }
}
