using Microsoft.AspNetCore.Identity;
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
        private readonly IPasswordHasher<User> _hasher;

        public StudentSeeder(MyLibrusDbContext myLibrusDbContext, IPasswordHasher<User> hasher)
        {
            _myLibrusDbContext = myLibrusDbContext;
            _hasher = hasher;
        }

        public void Seed()
        {
            // ensure that we have connection to DB
            if (_myLibrusDbContext.Database.CanConnect())
            {
                if (!_myLibrusDbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _myLibrusDbContext.Roles.AddRange(roles);
                    _myLibrusDbContext.SaveChanges();
                }


                // check if we have any data in DB
                if (!_myLibrusDbContext.Students.Any())
                {
                    var students = GetStudents();
                    _myLibrusDbContext.Students.AddRange(students);
                    _myLibrusDbContext.SaveChanges();
                }

                if (_myLibrusDbContext.Users.Any())
                {
                    _myLibrusDbContext.RemoveRange(_myLibrusDbContext.Users);
                    _myLibrusDbContext.SaveChanges();

                    var students = GetStudents();
                    _myLibrusDbContext.Students.AddRange(students);
                    _myLibrusDbContext.SaveChanges();
                }
                if (!_myLibrusDbContext.Users.Any())
                {
                    var users = GetUsers();
                    _myLibrusDbContext.Users.AddRange(users);
                    _myLibrusDbContext.SaveChanges();
                }
            }
        }

        public List<User> GetUsers()
        {
            

            var users = new List<User>();

                var User1 = new User
                {
                    FirstName = "Mariusz",
                    LastName = "Lajs",
                    Mail = "kalisz@kalisz.pl",
                    RoleId = 1                    
                };
            var password1 = "robot1";
            var user1Password = _hasher.HashPassword(User1, password1);
            User1.PasswordHashed = user1Password;

            var User2 = new User
            {
                FirstName = "kuba",
                LastName = "okurowski",
                Mail = "student@api.pl",
                RoleId = 1
            };
            var password2 = "mateusz";
            var user2Password = _hasher.HashPassword(User1, password2);
            User2.PasswordHashed = user2Password;

            var User3 = new User
            {
                FirstName = "Tymek",
                LastName = "Bemka",
                Mail = "teacherk@api.pl",
                RoleId = 2
            };
            var password3 = "mateusz";
            var user3Password = _hasher.HashPassword(User1, password3);
            User3.PasswordHashed = user3Password;

            var User4 = new User
            {
                FirstName = "Franczela",
                LastName = "Dizmo",
                Mail = "admin@api.pl",
                RoleId = 3
                
            };
            var password4 = "mateusz";
            var user4Password = _hasher.HashPassword(User1, password4);
            User4.PasswordHashed = user4Password;

            users.Add(User1);
            users.Add(User2);
            users.Add(User3);
            users.Add(User4);

            return users;
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
