using AutoMapper;
using Moq;
using MyLibrus.Entities;
using MyLibrus.Entities.DTO;
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
        //Grade service needs Grade Repository, so we need to mock it
        private readonly Mock<IGradeRepository> gradeRepositoryMock;
        private readonly Mock<IStudentRepository> studentRepositoryMock;
        //service under test
        private readonly IGradeService _sut;

        public UnitTest1()
        {
            this.gradeRepositoryMock = new Mock<IGradeRepository>();
            this.studentRepositoryMock = new Mock<IStudentRepository>();
            // below we just add repo to constructor (constructor of service requires repository)
            //_sut = new GradeService(this.gradeRepositoryMock.Object, this.studentRepositoryMock.Object);
        }

        [Fact]
        public void GetGradesTesting()
        {
            //Arrange
            var id = 2;
            var student = GetStudentGrades();
            gradeRepositoryMock
                .Setup(x => x.GetAll(id))
                .Returns(student);
            //Act

            var grades = _sut.GetAllGrades(id);
            

            //Assert

            
        }

        [Fact]
        public void GetGradeTest()
        {
            var id = It.IsAny<int>();

            gradeRepositoryMock
                .Setup(x => x.GetAll(id))
                .Returns(GetGrade());

            _sut.GetAllGrades(id);

            // dana metoda wykona siê albo siê nie wykona
            this.gradeRepositoryMock.Verify(v => v.DeleteGrade(id), Times.Never);
            this.gradeRepositoryMock.Verify(v => v.GetAll(id), Times.Once);                              
        }
        [Fact]
        public void GetGradesFromNullStudent()
        {
            var id = It.IsAny<int>();

            var grades = GetStudentGrades();

            //gradeRepositoryMock
            //    .Setup(x => x.GetAll(id))
            //    .Returns(GetNullGradeList());

            gradeRepositoryMock
                .Setup(x => x.GetAll(id))
                .Returns(grades);

            //we return not existing student
            studentRepositoryMock
                .Setup(x => x.GetStudent(id))
                .Returns(GetStudent());

            var result = _sut.GetAllGrades(id);

            var expected = GetStudentOnlyGrades();

            Assert.Same(expected, result);
            //Assert.True(expected.Equals(result));
        }       

        public List<Grade> GetGrade()
        {
            var list = new List<Grade>()
            {
                new Grade()
            {
                Id = 4,
                SingleGrade = 3,
                Subject = "Chemist",
                StudentId = 2
            },
                new Grade()
            {
                Id = 5,
                SingleGrade = 2,
                Subject = "Chemist",
                StudentId = 2
            }
        };
            return list;        

        }

        public List<Grade> GetNullGradeList()
        {            
            return null;
        }

        public Student GetNullStudent()
        {
            return null;
        }

        public List<Student> GetStudents()
        {
            var students = new List<Student>()
          {
              new Student
              {
                  Name = "Mateusz",
                  LastName = "Ulaniec",
                  Age = 18,
                  StudentClass = "3B",
                  Grades = new List<Grade>
                  {
                      new Grade()
                      {
                          SingleGrade = 1,
                          Subject = "Math"
                      },

                      new Grade()
                      {
                          SingleGrade = 5,
                          Subject = "English"
                      },

                      new Grade()
                      {
                          SingleGrade = 3,
                          Subject = "Chemist"
                      }
                  },
                  Contact = new Contact()
                  {
                      Mail = "mateusza@xd.pl",
                      Street = "ul mateusza"
                  }
              },

              new Student
              {
                  Name = "Pawel",
                  LastName = "Irak",
                  Age = 43,
                  StudentClass = "2A",
                  Grades = new List<Grade>
                  {
                      new Grade()
                      {
                          SingleGrade = 6,
                          Subject = "Math"
                      },

                      new Grade()
                      {
                          SingleGrade = 6,
                          Subject = "English"
                      },

                      new Grade()
                      {
                          SingleGrade = 6,
                          Subject = "Chemist"
                      }
                  },
                  Contact = new Contact()
                  {
                      Mail = "pawel@xd.pl",
                      Street = "ul pawla"
                  }
              },

              new Student
              {
                  Name = "Filippa",
                  LastName = "Eithard",
                  Age = 23,
                  StudentClass = "1E",
                  Grades = new List<Grade>
                  {
                      new Grade()
                      {
                          SingleGrade = 1,
                          Subject = "Math"
                      },

                      new Grade()
                      {
                          SingleGrade = 2,
                          Subject = "English"
                      },

                      new Grade()
                      {
                          SingleGrade = 4,
                          Subject = "Chemist"
                      }
                  },
                  Contact = new Contact()
                  {
                      Mail = "filipa@xd.pl",
                      Street = "ulica filipy"
                  }
              },

              new Student
              {
                  Name = "aleksandra",
                  LastName = "£ajs",
                  Age = 34,
                  StudentClass = "2A",
                  Grades = new List<Grade>
                  {
                      new Grade()
                      {
                          SingleGrade = 4,
                          Subject = "Math"
                      },

                      new Grade()
                      {
                          SingleGrade = 4,
                          Subject = "English"
                      },

                      new Grade()
                      {
                          SingleGrade = 4,
                          Subject = "Chemist"
                      }
                  },
                  Contact = new Contact()
                  {
                      Mail = "aleksandra@xd.pl",
                      Street = "ulica aleksandry"
                  }
              },
          };

            return students;


        }

        public List<Grade> GetStudentOnlyGrades()
        {
            var student = new Student
            {
                Name = "Mateusz",
                LastName = "Ulaniec",
                Age = 18,
                StudentClass = "3B",
                Grades = new List<Grade>
                  {
                      new Grade()
                      {
                          SingleGrade = 1,
                          Subject = "Math"
                      },

                      new Grade()
                      {
                          SingleGrade = 5,
                          Subject = "English"
                      },

                      new Grade()
                      {
                          SingleGrade = 3,
                          Subject = "Chemist"
                      }
                  },
                Contact = new Contact()
                {
                    Mail = "mateusza@xd.pl",
                    Street = "ul mateusza"
                }
            };

            return student.Grades;
        }

        public List<Grade> GetStudentGrades()
        {
            var grades = new List<Grade>
                  {
                      new Grade()
                      {
                          Id = 0,
                          SingleGrade = 1,
                          Subject = "Math",
                          StudentId = 2
                      },

                      new Grade()
                      {
                          Id = 1,
                          SingleGrade = 5,
                          Subject = "English",
                          StudentId = 2
                      },

                      new Grade()
                      {
                          Id = 2,
                          SingleGrade = 3,
                          Subject = "Chemist",
                          StudentId = 2
                      }
                  };

            return grades;
        }

        public Student GetStudent()
        {
            var student = new Student
            {
                Name = "Mateusz",
                LastName = "Ulaniec",
                Age = 18,
                StudentClass = "3B",
                Grades = new List<Grade>
                  {
                      new Grade()
                      {
                          SingleGrade = 1,
                          Subject = "Math"
                      },

                      new Grade()
                      {
                          SingleGrade = 5,
                          Subject = "English"
                      },

                      new Grade()
                      {
                          SingleGrade = 3,
                          Subject = "Chemist"
                      }
                  },
                Contact = new Contact()
                {
                    Mail = "mateusza@xd.pl",
                    Street = "ul mateusza"
                }
            };

            return student;
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
    }
}







