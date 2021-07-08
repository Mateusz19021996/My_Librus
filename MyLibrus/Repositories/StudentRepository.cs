using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
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
        private readonly IMapper _mapper;

        public StudentRepository(MyLibrusDbContext myLibrusDbContext, IMapper mapper)
        {
            _myLibrusDbContext = myLibrusDbContext;
            _mapper = mapper;
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            var students = _myLibrusDbContext
                .Students
                .Include(x => x.Grades)
                .Include(t => t.Contact)
                .ToList();

            var studentsDto = _mapper.Map<List<StudentDTO>>(students);

            return studentsDto;
        }

        public StudentDTO GetStudent(int id)
        {
            var student = _myLibrusDbContext
                .Students
                .Include(x => x.Contact)
                .Include(y => y.Grades)
                .FirstOrDefault(x => x.Id == id);

            var studentDto = _mapper.Map<StudentDTO>(student);

            return studentDto;
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
