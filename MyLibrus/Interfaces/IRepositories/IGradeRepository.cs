using MyLibrus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Interfaces.IRepositories
{
    interface IGradeRepository
    {
        public IEnumerable<Grade> GetAll();
        public Grade GetGrade();
        public void AddGrade();
        public void DeleteGrade();
        public void UpdateGrade();
    }
}
