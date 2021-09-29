using AutoMapper;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
using MyLibrus.Entities.DTO.EditDTO;
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
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Contact.Street))
                .ForMember(x => x.Grades, y => y.MapFrom(z => z.Grades));                
            // mapujemy z danego typu na drugi. Musimy wskazac z czego chcemy
            // zmapować nasze pola w DTO. Jesli nazywają się tak samo, nie musimy
            // ich mapować. AM zrobi to za nas

            CreateMap<Grade, GradeDTO>()
                .ForMember(x => x.StudentFirstName, y => y.MapFrom(z => z.Student.Name))
                .ForMember(x => x.StudentSurname, y => y.MapFrom(z => z.Student.LastName));

            CreateMap<CreateStudentDTO, Student>()
                .ForMember(x => x.Contact, y => y.MapFrom(dto => new Contact()
                {
                    Street = dto.Street,
                    Mail = dto.Mail
                }));

            CreateMap<CreateGradeDTO, Grade>();

            CreateMap<EditStudentDTO, Student>()
                .ForMember(x => x.Contact, y => y.MapFrom(dto => new Contact()
                {
                    Street = dto.Street,
                    Mail = dto.Mail
                }));
        }
    }
}
