using AutoMapper;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
using MyLibrus.Entities.DTO.EditDTO;
using MyLibrus.Exceptions;
using MyLibrus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Services
{
    public interface IGradeService
    {
        public IEnumerable<GradeDTO> GetAllGrades(int id);
        public void AddGrade(CreateGradeDTO createGradeDTO);
        public void DeleteGrade(int id);
        public void UpdateGrade(EditGradeDTO editGradeDTO);
    }

    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GradeService(IGradeRepository gradeRepository, IStudentRepository studentRepository, IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public IEnumerable<GradeDTO> GetAllGrades(int id)
        {
            //check if student exist
            var student = _studentRepository.GetStudent(id);

            if(student == null)
            {
                throw new NotFoundException("Student does not exist");
            }
            else
            {
                var grades = _gradeRepository.GetAll(id);
                var gradesDTO = _mapper.Map<List<GradeDTO>>(grades);
                return gradesDTO;
            }            
        }

        public void AddGrade(CreateGradeDTO createGradeDTO)
        {
            var student = _studentRepository
                .GetStudent(createGradeDTO.StudentId);

            if(student == null)
            {
                throw new NotFoundException("Student does not exist");
            }
            else
            {
                var grade = _mapper.Map<Grade>(createGradeDTO);
                _gradeRepository.AddGrade(grade);
            }           
        }

        public void DeleteGrade(int id)
        {
            //var grade 
        }
        
        public void UpdateGrade(EditGradeDTO editGradeDTO)
        {
            var student = _studentRepository
                .GetStudent(editGradeDTO.StudentId);

            var grade = _gradeRepository
                .GetGrade(editGradeDTO.Id);

            if(student == null)
            {
                throw new NotFoundException("Student does not exist");
            }
            if(grade == null)
            {
                throw new NotFoundException("Grade does not exist");
            }
            else
            {
                var newGrade = _mapper.Map<Grade>(editGradeDTO);
            }


        }
    }
}
