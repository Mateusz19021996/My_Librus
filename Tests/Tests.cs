//using AutoMapper;
//using Moq;
//using MyLibrus.Entities;
//using MyLibrus.Entities.DTO;
//using MyLibrus.Entities.DTO.EditDTO;
//using MyLibrus.Repositories;
//using MyLibrus.Services;
//using MyLibrus.Validation;
//using System;
//using System.Collections.Generic;
//using Xunit;

//namespace Tests
//{
//    public class Tests
//    {
//        // sprawdzic, czy metoda getById pobierze mi konkretnego studenta
//        // lub czy wyrzuci null, jesli dany student nie istnieje

//        // testujemy klasę StudentService
//        // ma ona dependencje do StudentRepository


        

//        private readonly StudentService _sut;

//        //  0. Mockujemy interfejs

//        private readonly Mock<IStudentRepository> _studentRepoMock = new Mock<IStudentRepository>();
//        private readonly Mock<IMapper> _studentMapperMock = new Mock<IMapper>();
        

//        public Tests()
//        {
//            //tworzymy obiekt naszej klasy, wrzucajac nasze zmockowane klasy
//            //_sut = new StudentService(_studentRepoMock.Object, _studentMapperMock.Object);
            
//        }
        
//        //  1. Tworzymy metode
//        [Fact]
//        public void StudentServiceCheck()
//        {
//            var id = 2;
//            var Retstudent = GetStudent();
//            _studentRepoMock
//                .Setup(x => x.GetStudent(id))
//                .Returns(Retstudent);


//            var student = Retstudent;

//            Assert.Equal(id, student.Id);
//        }

//        // sprawdzamy czy student po edycji bedzie zmieniony
//        [Fact]
//        public void StudentUpdateCheck()
//        {
//            var id = 2;
//            var student = GetStudent();
//            var studentAfterEdit = GetStudentAfterEdit();
//            var studentDTO = 

//            _studentRepoMock
//                .Setup(x => x.GetStudent(id))
//                .Returns(student);

//            _studentMapperMock
//                .Setup(x => x.Map<Student>(studentDTO))
//                .Returns(studentAfterEdit);

//            var check =
//                _sut.EditStudent(studentDTO, id);

//            // to DB

                    
//            //Assert.True(check);
//            Assert.Equal(student.Name, studentAfterEdit.Name);
            



//        }

//        public Student GetStudent()
//        {
//            var student = new Student
//            {
//                Id = 2,
//                Name = "Mateusz",
//                LastName = "Ulaniec",
//                Age = 18,
//                StudentClass = "3B",
//                Grades = new List<Grade>
//                  {
//                      new Grade()
//                      {
//                          SingleGrade = 1,
//                          Subject = "Math"
//                      },

//                      new Grade()
//                      {
//                          SingleGrade = 5,
//                          Subject = "English"
//                      },

//                      new Grade()
//                      {
//                          SingleGrade = 3,
//                          Subject = "Chemist"
//                      }
//                  },
//                Contact = new Contact()
//                {
//                    Mail = "mateusza@xd.pl",
//                    Street = "ul mateusza"
//                }
//            };

//            return student;
//        }

//        public Student GetStudentAfterEdit()
//        {
//            var student = new Student
//            {
//                Id = 2,
//                Name = "Jasmin",
//                LastName = "Ulaniec",
//                Age = 30,
//                StudentClass = "3B",
//                Grades = new List<Grade>
//                  {
//                      new Grade()
//                      {
//                          SingleGrade = 1,
//                          Subject = "Math"
//                      },

//                      new Grade()
//                      {
//                          SingleGrade = 5,
//                          Subject = "English"
//                      },

//                      new Grade()
//                      {
//                          SingleGrade = 3,
//                          Subject = "Chemist"
//                      }
//                  },
//                Contact = new Contact()
//                {
//                    Mail = "chrzanowo@wp.pl",
//                    Street = "ul.Lajs 14"
//                }
//            };

//            return student;
//        }

//        //public EditStudentDTO EditStudentDTO()
//        //{
//        //    //var student = new EditStudentDTO()
//        //    //{
//        //    //    Name = "Jasmin",                
//        //    //    Age = 30,
//        //    //    Street = "ul.Lajs 14",
//        //    //    Email = "chrzanowo@wp.pl"
//        //    //};

//        //    return student;
//        //}


//    }
//}
