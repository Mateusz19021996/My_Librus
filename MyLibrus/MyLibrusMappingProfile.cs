using AutoMapper;
using MyLibrus.Controllers;
using MyLibrus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus
{
    public class MyLibrusMappingProfile: Profile
    {
        public MyLibrusMappingProfile()
        {
            ////CreateMap<Student, StudentDto>()
            ////    // if the names in Student and StudentDto are the same we dont need to create mapping
            ////    .ForMember(m => m.Mail, k => k.MapFrom(s => s.Contact.Mail));
                

            ////CreateMap<Grade, GradeDto>();                

            ////create student
            //CreateMap<CreateStudentDto, Student>()
            //    .ForMember(x => x.Contact, m => m.MapFrom(dto => new Contact()
            //    {
            //        //Mail = dto.Mail,
            //        //Street = dto.Street

            //    }));
            
            
        }
    }
}
