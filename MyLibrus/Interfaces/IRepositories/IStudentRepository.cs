using MyLibrus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Interfaces.IRepositories
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAll();
        public Student GetStudent(int id);
        public void CreateStudent(Student student);
        public void DeleteStudent(int id);
        public void UpdateStudent(Student student, int id);
    }
}
