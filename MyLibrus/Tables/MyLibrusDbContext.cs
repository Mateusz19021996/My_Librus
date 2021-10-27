using Microsoft.EntityFrameworkCore;
using MyLibrus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrus.Tables
{
    // here we will create properties. Every property is one table in DB.
    public class MyLibrusDbContext: DbContext
    {
        //add table Students
        public DbSet<Student> Students { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        //we can add special properties for every column in table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);          
        }
        

        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=MyLibrusDbv1;Trusted_Connection=True;";

        //here we configurating our connect to DB
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
