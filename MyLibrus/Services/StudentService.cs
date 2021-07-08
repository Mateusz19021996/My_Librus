using AutoMapper;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
using MyLibrus.Interfaces.IRepositories;
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
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public IEnumerable GetStudents()
        {
            var students = _studentRepository.GetAll();                

            return students;
        }

        public StudentDTO GetStudent(int id)
        {
            var student = _studentRepository
                .GetStudent(id);

            if(student == null)
            {
                return null;
            }else
            {
                return student;
            }            
        }

        public int CreateStudent(CreateStudentDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

             _studentRepository.CreateStudent(student);

            return student.Id;
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
