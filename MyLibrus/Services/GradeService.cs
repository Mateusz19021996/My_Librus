using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
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

    public class GradeService
    {

    }
}
