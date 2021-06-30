using MyLibrus.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Interfaces.IServices
{
    public interface IStudentService
    {
        public IEnumerable GetStudents();
        public Student GetStudent(int id);
        public void CreateStudent(Student student);
        public void DeleteStudent(int id);
        public void EditStudent(Student student, int id);
    }
}
