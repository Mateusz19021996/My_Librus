using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities.DTO.EditDTO
{
    public class EditGradeDTO
    {
        public int Id { get; set; }

        public int SingleGrade { get; set; }

        public string Subject { get; set; }

        public int StudentId { get; set; }
    }
}
