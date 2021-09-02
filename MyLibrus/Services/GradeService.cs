using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
using MyLibrus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Services
{
    public interface IGradeService
    {
        public IEnumerable<Grade> GetAllGrades(int id);
        public IEnumerable<Grade> GetAllGradesBySubject(string subject);
        public void AddGrade(CreateGradeDTO createGradeDTO);
        public void DeleteGrade(int id);
        public void UpdateGrade();
    }

    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository _studentRepository;

        public GradeService(IGradeRepository gradeRepository, IStudentRepository studentRepository)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
        }

        public IEnumerable<Grade> GetAllGrades(int id)
        {
            //var student = _studentRepository.GetStudent(id);

            //if(student == null)
            //{
            //    return null;
            //}
            //else
            //{
            //    var grades = _gradeRepository.GetAll(id);
            //    return grades;
            //}

            var grades = _gradeRepository.GetAll(id);
            return grades;
        }

        public IEnumerable<Grade> GetAllGradesBySubject(string subject)
        {
            throw new NotImplementedException();
        }

        public void AddGrade(CreateGradeDTO createGradeDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteGrade(int id)
        {
            throw new NotImplementedException();
        }

        

        public void UpdateGrade()
        {
            throw new NotImplementedException();
        }
    }
}
