using AutoMapper;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus
{
    public class MyLibrusMappingProfile : Profile
    {
        public MyLibrusMappingProfile()
        {
            //jak cos sie pokrywa typem i nazwa to nie trzeba tego mapować
            CreateMap<Student, StudentDTO>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Mail, y => y.MapFrom(z => z.Contact.Mail))
                .ForMember(x => x.Grades, y => y.MapFrom(z => z.Grades));

            CreateMap<Grade, GradeDTO>();
        }
    }
}
