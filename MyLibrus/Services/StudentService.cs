using AutoMapper;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
using MyLibrus.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using System.ComponentModel.DataAnnotations;
using MyLibrus.Entities.DTO.EditDTO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MyLibrus.Authorization;
using Microsoft.Extensions.Logging;
using MyLibrus.Exceptions;

namespace MyLibrus.Services
{
    public interface IStudentService
    {
        public IEnumerable GetStudents();
        public StudentDTO GetStudent(int id);
        public void CreateStudent(CreateStudentDTO studentDto);
        public bool DeleteStudent(int id);
        public bool EditStudent(EditStudentDTO editStudentDto, int id);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;
        private readonly IAuthorizationService _authorizateService;

        public StudentService(IStudentRepository studentRepository, IMapper mapper, ILogger<StudentService> logger)
            //IAuthorizationService authorizateService)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _logger = logger;
            //_authorizateService = authorizateService;
        }

       

        public IEnumerable GetStudents()
        {
            var students = _studentRepository.GetAll();

            var studentsDto = _mapper.Map<List<StudentDTO>>(students);
            _logger.LogInformation($"Method GetStudents() invoked");
            _logger.LogError($"no jest wysoko");
            
            return studentsDto;
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
                var studentDto = _mapper.Map<StudentDTO>(student);

                return studentDto;
            }            
        }

        public void CreateStudent(CreateStudentDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

             _studentRepository.CreateStudent(student);
            
        }

        public bool EditStudent(EditStudentDTO editStudentDto, int id)
        {
            var studentToUpdate = _studentRepository.GetStudent(id);

            if (studentToUpdate == null)
            {
                return false;
            }
            else
            {
                var editedStudent = _mapper.Map<Student>(editStudentDto);

                studentToUpdate.Age = editedStudent.Age;
                studentToUpdate.Name = editedStudent.Name;
                studentToUpdate.LastName = editedStudent.LastName;
                Console.WriteLine(studentToUpdate.Contact.Street);
                studentToUpdate.Contact.Street = editedStudent.Contact.Street;
                Console.WriteLine(studentToUpdate.Contact.Street);
                Console.WriteLine(studentToUpdate.Contact.Mail);
                studentToUpdate.Contact.Mail = editedStudent.Contact.Mail;
                Console.WriteLine(studentToUpdate.Contact.Mail);

                _studentRepository.UpdateStudent();

                Console.WriteLine("wywołało się update");
                

                return true;
            }


                                   
        }

        public bool DeleteStudent(int id)
        {
            var student = _studentRepository.GetStudent(id);
            
            if(student == null)
            {
                throw new Exception();
            }
            else
            {
                var idToDelete = student.Id;
                _studentRepository.DeleteStudent(idToDelete);
            }

            //check if student was deleted
            var check = _studentRepository.GetStudent(id);

            if(check == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }                        
    }
}
