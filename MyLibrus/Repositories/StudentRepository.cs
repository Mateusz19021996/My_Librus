using MyLibrus.Entities;
using MyLibrus.Interfaces.IRepositories;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public readonly MyLibrusDbContext _myLibrusDbContext;

        public StudentRepository(MyLibrusDbContext myLibrusDbContext)
        {
            _myLibrusDbContext = myLibrusDbContext;
        }

        public IEnumerable<Student> GetAll()
        {
            var students = _myLibrusDbContext
                .Students
                .ToList();

            return students;
        }

        public Student GetStudent(int id)
        {
            var student = _myLibrusDbContext
                .Students
                .FirstOrDefault(x => x.Id == id);

            return student;
        }

        public void CreateStudent(Student student)
        {
            _myLibrusDbContext.Students.Add(student);
            _myLibrusDbContext.SaveChanges();
                
        }

        public void DeleteStudent(int id)
        {
            var student = _myLibrusDbContext
                .Students
                .FirstOrDefault(x => x.Id == id);

            _myLibrusDbContext
                .Students
                .Remove(student);

            _myLibrusDbContext.SaveChanges();   

            
        }
      
        public void UpdateStudent(Student student, int id)
        {
            var studentToUpdate = _myLibrusDbContext
                .Students
                .FirstOrDefault(x => x.Id == id);

            student.Name = studentToUpdate.Name;
            student.Age = student.Age;
        }
    }
}
