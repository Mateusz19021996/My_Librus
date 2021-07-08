using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Interfaces.IRepositories
{
    public interface IStudentRepository
    {
        public IEnumerable<StudentDTO> GetAll();
        public StudentDTO GetStudent(int id);
        public void CreateStudent(Student student);
        public void DeleteStudent(int id);
        public void UpdateStudent(Student student, int id);
    }
}
