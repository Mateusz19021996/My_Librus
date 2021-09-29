using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities.DTO.GetDTO
{
    public class GradesStudentSubjectDTO
    {
        public int StudentId { get; set; }

        public List<GetSubjectWithGrades> ListOfGrades { get; set; }
  
    }

    public class GetSubjectWithGrades 
    {
        public string Subject { get; set; }

        public List<int> Grades { get; set; }
    }


}
