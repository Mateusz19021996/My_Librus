using MyLibrus.Entities;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Services
{
    public class AccountService
    {
        private readonly MyLibrusDbContext _myLibrusDbContext;
        

        public AccountService(MyLibrusDbContext myLibrusDbContext)
        {
            _myLibrusDbContext = myLibrusDbContext;
        }

       
        


    }
}
