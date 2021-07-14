using MyLibrus.Entities;
using MyLibrus.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus
{
    public class StudentSeeder
    {
        private readonly MyLibrusDbContext _myLibrusDbContext;

        public StudentSeeder(MyLibrusDbContext myLibrusDbContext)
        {
            _myLibrusDbContext = myLibrusDbContext;
        }

        public void Seed()
        {
            // ensure that we have connection to DB
            if (_myLibrusDbContext.Database.CanConnect())
            {
                if (!_myLibrusDbContext.Roles.Any())
                {
                    var users = GetRoles();
                    _myLibrusDbContext.Roles.AddRange(users);
                    _myLibrusDbContext.SaveChanges();
                }


                // check if we have any data in DB
                if (!_myLibrusDbContext.Students.Any())
                {
                    var students = GetStudents();
                    _myLibrusDbContext.Students.AddRange(students);
                    _myLibrusDbContext.SaveChanges();
                }
            }
        }

        public List<Role> GetRoles()
        {
            var users = new List<Role>()
            {
                new Role
                {
                    RoleName = "Student"
                },
                new Role
                {
                    RoleName = "Teacher"
                },
                new Role
                {
                    RoleName = "Admin"
                }
            };

            return users;
        }

        public List<Student> GetStudents()
        {
            var students = new List<Student>()
          {
              new Student
              {
                  Name = "Mateusz",
                  Age = 18,                  
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
                  Age = 43,
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
                  Age = 23,
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
                  Age = 34,
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
    }
}
