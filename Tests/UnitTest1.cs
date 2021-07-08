using Moq;
using MyLibrus.Entities.DTO;
using MyLibrus.Interfaces.IRepositories;
using MyLibrus.Interfaces.IServices;
using MyLibrus.Repositories;
using MyLibrus.Services;
using MyLibrus.Validation;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        //private readonly IStudentService _sut;

        //public UnitTest1(IStudentService sut)
        //{
        //    _sut = sut;
        //}

        [Fact]
        public void Test1()
        {
            //Arange

            var ut = new Validator();

            //Act

            var result = ut.Dator(5);

            //Assert

            Assert.Equal(15, result);
        }

        //czy taki test ma wgl sens?
        [Fact]
        public void Test_of_GetAllStudents()
        {
            var listOfStudents = ListOfStudents();
            Mock<IStudentRepository> mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(x => x.GetAll())
                .Returns(listOfStudents);

            //var cls = new StudentService(mockRepo.Object);

            //var result = cls.GetStudents();
            

            //Assert.Equal(result, listOfStudents);
        }

        [Fact]
        public void Test_of_GetAllStudents2()
        {
            
            Mock<IStudentRepository> mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(x => x.GetAll())
                .Returns(ListOfStudents());
            // czy Tu nie przechodzi dlatego, ¿e ListOfStudents tworzy nowe obiekty?

            // co Gdyby metoda listOFsTUDENTS ZWARACa³a tylko np. 2, a nie tworyzla nowy obiekt?
            //var cls = new StudentService(mockRepo.Object);

            var listOfStudents = ListOfStudents();
            //var result = cls.GetStudents();


           // Assert.Equal(result, listOfStudents);
        }

        public List<StudentDTO> ListOfStudents()
        {
            var list = new List<StudentDTO>()
            {
                new StudentDTO
            {
                Name = "Mateusz",
                Age = 24,
                Mail = "xd@gmail.com",
                Grades = new List<GradeDTO>()
                {
                    new GradeDTO
                        {
                            SingleGrade = 4,
                            Subject = "History",
                            StudentId = 4
                        },
                    new GradeDTO
                        {
                            SingleGrade = 5,
                            Subject = "Mat",
                            StudentId = 4
                        }
                }
            },
                new StudentDTO
            {
                Name = "Marta",
                Age = 32,
                Mail = "marta@gmail.com",
                Grades = new List<GradeDTO>()
                {
                    new GradeDTO
                        {
                            SingleGrade = 2,
                            Subject = "History",
                            StudentId = 2
                        },
                    new GradeDTO
                        {
                            SingleGrade = 3,
                            Subject = "Mat",
                            StudentId = 2
                        }
                }
            } };
            return list;
        }

        public StudentDTO rStudentDTO()
        {
            var StudentDTo = new StudentDTO
            {
                Name = "Mateusz",
                Age = 24,
                Mail = "xd@gmail.com",
                Grades = new List<GradeDTO>()
                {
                    new GradeDTO
                        {
                            SingleGrade = 4,
                            Subject = "History",
                            StudentId = 4
                        },
                    new GradeDTO
                        {
                            SingleGrade = 5,
                            Subject = "Mat",
                            StudentId = 4
                        }
                }
            };
            return StudentDTo;
        }
    }
}




