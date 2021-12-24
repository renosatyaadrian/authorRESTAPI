using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authorRESTAPI.Models;

namespace authorRESTAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if(context.Authors.Any())
            {
                return;
            }

            var authors = new Author[]
            {
                new Author{FirstName="Reno",LastName="Satya",DateOfBirth=DateTime.Parse("1997-07-04"),MainCategory="Programming"},
                new Author{FirstName="Reza",LastName="Aditya",DateOfBirth=DateTime.Parse("1995-12-12"),MainCategory="Fiction"},
                new Author{FirstName="Reni",LastName="Setyorini",DateOfBirth=DateTime.Parse("1993-02-02"),MainCategory="Programming"},  
            };

            foreach (var a in authors)
            {
                context.Authors.Add(a);
            }

            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{Title="Cloud Fundamentals",Description="Belajar Cloud Fundamentals"},
                new Course{Title="Microservices Architecture",Description="Belajar dasar dasar mircoservices"},
                new Course{Title="Backend RESTful API",Description="Mengenali Backend dengan penerapan RESTful API"},
            };

            foreach (var c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{AuthorID=1,CourseID=1},
                new Enrollment{AuthorID=1,CourseID=3},
                new Enrollment{AuthorID=2,CourseID=1},
                new Enrollment{AuthorID=2,CourseID=2},
                new Enrollment{AuthorID=2,CourseID=3},
                new Enrollment{AuthorID=3,CourseID=1},
            };

            foreach(var e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}