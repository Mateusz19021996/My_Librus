using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Security
{
    public class GradeOperationRequirement : IAuthorizationRequirement
    {
        //public string TeacherMainSubject { get; set; }

        public GradeOperationRequirement()
        {
            
        }
    }
}
