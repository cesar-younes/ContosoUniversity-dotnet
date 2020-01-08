using ContosoUniversity.Data;
using ContosoUniversity.Models;
using System;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{Id=Guid.NewGuid().ToString(),FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Student{Id=Guid.NewGuid().ToString(),FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{Id=Guid.NewGuid().ToString(),FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{Id=Guid.NewGuid().ToString(),FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{Id=Guid.NewGuid().ToString(),FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{Id=Guid.NewGuid().ToString(),FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{Id=Guid.NewGuid().ToString(),FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{Id=Guid.NewGuid().ToString(),FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2019-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{Id=Guid.NewGuid().ToString(),Title="Chemistry",Credits=3},
                new Course{Id=Guid.NewGuid().ToString(),Title="Microeconomics",Credits=3},
                new Course{Id=Guid.NewGuid().ToString(),Title="Macroeconomics",Credits=3},
                new Course{Id=Guid.NewGuid().ToString(),Title="Calculus",Credits=4},
                new Course{Id=Guid.NewGuid().ToString(),Title="Trigonometry",Credits=4},
                new Course{Id=Guid.NewGuid().ToString(),Title="Composition",Credits=3},
                new Course{Id=Guid.NewGuid().ToString(),Title="Literature",Credits=4}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{Id=Guid.NewGuid().ToString(),StudentId=students[0].Id,CourseId=courses[0].Id,Grade=Grade.A},
                new Enrollment{Id=Guid.NewGuid().ToString(),StudentId=students[0].Id,CourseId=courses[1].Id,Grade=Grade.C},
                new Enrollment{Id=Guid.NewGuid().ToString(),StudentId=students[0].Id,CourseId=courses[2].Id,Grade=Grade.B},
                new Enrollment{Id=Guid.NewGuid().ToString(),StudentId=students[2].Id,CourseId=courses[0].Id,Grade=Grade.B},
                new Enrollment{Id=Guid.NewGuid().ToString(),StudentId=students[2].Id,CourseId=courses[1].Id,Grade=Grade.F},
                new Enrollment{Id=Guid.NewGuid().ToString(),StudentId=students[2].Id,CourseId=courses[2].Id,Grade=Grade.F},
                new Enrollment{Id=Guid.NewGuid().ToString(),StudentId=students[3].Id,CourseId=courses[3].Id},
                new Enrollment{Id=Guid.NewGuid().ToString(),StudentId=students[4].Id,CourseId=courses[4].Id},
                new Enrollment{Id=Guid.NewGuid().ToString(),StudentId=students[4].Id,CourseId=courses[5].Id,Grade=Grade.F},
                new Enrollment{Id=Guid.NewGuid().ToString(),StudentId=students[5].Id,CourseId=courses[6].Id,Grade=Grade.C},
                new Enrollment{Id=Guid.NewGuid().ToString(),StudentId=students[6].Id,CourseId=courses[3].Id},
                new Enrollment{Id=Guid.NewGuid().ToString(),StudentId=students[7].Id,CourseId=courses[4].Id,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}