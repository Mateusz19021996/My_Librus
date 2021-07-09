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
    public interface IStudentRepository
    {
        public IEnumerable<StudentDTO> GetAll();
        public StudentDTO GetStudent(int id);
        public void CreateStudent(Student student);
        public void DeleteStudent(int id);
        public bool UpdateStudent(Student student, int id);
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
      
        public bool UpdateStudent(Student student, int id)
        {
            var studentToUpdate = _myLibrusDbContext
                .Students
                .Include(c => c.Contact)
                .FirstOrDefault(x => x.Id == id);

            if (studentToUpdate == null)
            {
                return false;
            }

            studentToUpdate.Age = student.Age;
            studentToUpdate.Name = student.Name;
            studentToUpdate.Contact.Street = student.Contact.Street;
            studentToUpdate.Contact.Mail = student.Contact.Mail;

            _myLibrusDbContext.SaveChanges();
            // if operation is successfull return true
            return true;
        }
    }
}
