using MyLibrus.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Interfaces.IServices
{
    interface IGradeService
    {
        public IEnumerable getAll();
        public Grade getGrade(int id);
        public void AddGrade(Grade grade);
        public void ChangeGrade(Grade grade, int id);
        public void DeleteGrade(int id);

    }
}
