using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Repositories
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAll();
        public Student GetStudent(int id);
        public void CreateStudent(Student student);
        public void DeleteStudent(int id);
        public void UpdateStudent();
    }

    public class StudentRepository : IStudentRepository
    {
        public readonly MyLibrusDbContext _myLibrusDbContext;
        private readonly IMapper _mapper;

        public StudentRepository(MyLibrusDbContext myLibrusDbContext, IMapper mapper)
        {
            _myLibrusDbContext = myLibrusDbContext;
            _mapper = mapper;
        }

        public IEnumerable<Student> GetAll()
        {
            var students = _myLibrusDbContext
               .Students
               .Include(x => x.Grades)
               .Include(t => t.Contact)
               .ToList();

            return students;
        }

        public Student GetStudent(int id)
        {
            var student = _myLibrusDbContext
                .Students
                .Include(x => x.Contact)
                .Include(y => y.Grades)
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

        public void UpdateStudent()
        {
            _myLibrusDbContext.SaveChanges();
        }
    }
}