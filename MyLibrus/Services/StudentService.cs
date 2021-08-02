using AutoMapper;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
using System.Web.Http.ModelBinding;
using System.ComponentModel.DataAnnotations;
using MyLibrus.Entities.DTO.EditDTO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MyLibrus.Authorization;

namespace MyLibrus.Services
{
    public interface IStudentService
    {
        public IEnumerable GetStudents();
        public StudentDTO GetStudent(int id);
        public void CreateStudent(CreateStudentDTO studentDto);
        public void DeleteStudent(int id, ClaimsPrincipal user);
        public bool EditStudent(EditStudentDTO editStudentDto, int id);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizateService;

        public StudentService(IStudentRepository studentRepository, IMapper mapper, 
            IAuthorizationService authorizateService)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _authorizateService = authorizateService;
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

        public void CreateStudent(CreateStudentDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

             _studentRepository.CreateStudent(student);
            
        }

        public bool EditStudent(EditStudentDTO editStudentDto, int id)
        {

            try
            {
                throw new Exception("xddddddddddd");
            }
            catch (Exception e)
            {
                return true;
            }

            var student = _mapper.Map<Student>(editStudentDto);

            var update = _studentRepository.UpdateStudent(student, id);

            if(update == true)
            {
                return true;
            } else
            {
                return false;
            }

            
        }

        public void DeleteStudent(int id, ClaimsPrincipal user)
        {
            var student = _studentRepository.GetStudent(id);

            // logika do badania 
            var authorizationResult = 
                _authorizateService.AuthorizeAsync(user, student, new ContactEdit(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new Exception("cos Ci mordko nie poszlo xd");
            }

            _studentRepository.DeleteStudent(id);
        }

        

        

        
    }
}
