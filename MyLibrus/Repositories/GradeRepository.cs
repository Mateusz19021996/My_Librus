using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Repositories
{

    public interface IGradeRepository
    {
        public IEnumerable<Grade> GetAll(int id);
        public IEnumerable<Grade> GetAllBySubject(string subject);
        public void AddGrade(CreateGradeDTO createGradeDTO);
        public void DeleteGrade(int id);
        public void UpdateGrade();
    }

    public class GradeRepository: IGradeRepository
    {
        private readonly MyLibrusDbContext _myLibrusDbContext;

        public GradeRepository(MyLibrusDbContext myLibrusDbContext)
        {
            _myLibrusDbContext = myLibrusDbContext;
        }

        public IEnumerable<Grade> GetAll(int id)
        {
            var grades = _myLibrusDbContext
                .Grades
                .Where(x => x.StudentId == id)
                .ToList();

            return grades;
                
        }

        public IEnumerable<Grade> GetAllBySubject(string subject)
        {
            throw new NotImplementedException();
        }

        public void AddGrade(CreateGradeDTO createGradeDTO)
        {
            throw new NotImplementedException();
        }

        public void UpdateGrade()
        {
            throw new NotImplementedException();
        }

        public void DeleteGrade(int id)
        {
            throw new NotImplementedException();
        }

        

        
    }
}
