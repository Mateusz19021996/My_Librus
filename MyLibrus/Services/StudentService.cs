using MyLibrus.Entities;
using MyLibrus.Interfaces.IServices;
using MyLibrus.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable GetStudents()
        {
            var students = _studentRepository.GetAll();

            return students;
        }

        public Student GetStudent(int id)
        {
            var student = _studentRepository
                .GetStudent(id);

            return student;
        }

        public void CreateStudent(Student student)
        {
             _studentRepository.CreateStudent(student);
        }

        public void EditStudent(Student student, int id)
        {
            _studentRepository.UpdateStudent(student, id);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }

        

        

        
    }
}
