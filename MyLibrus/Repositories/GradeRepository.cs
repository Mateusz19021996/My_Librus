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

    public interface IGradeRepository
    {
        public IEnumerable<Grade> GetAll(int id);
        public Grade GetGrade(int id);
        public void AddGrade(Grade grade);
        public void DeleteGrade(int id);
        public void UpdateGrade();
    }

    public class GradeRepository : IGradeRepository
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
                .Include(x => x.Student)
                .Where(x => x.StudentId == id)
                .ToList();

            return grades;

        }

        public IEnumerable<Grade> GetAllBySubject(string subject)
        {
            throw new NotImplementedException();
        }

        public void AddGrade(Grade grade)
        {
            _myLibrusDbContext.Grades.Add(grade);
            _myLibrusDbContext.SaveChanges();
        }

        public void UpdateGrade()
        {
            throw new NotImplementedException();
        }

        public void DeleteGrade(int id)
        {
            throw new NotImplementedException();
        }

        public Grade GetGrade(int id)
        {
            throw new NotImplementedException();
        }
    }
}