using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Entities.DTO.EditDTO
{
    public class EditStudentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Street { get; set; }

        public string Mail { get; set; }
    }
}
