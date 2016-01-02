namespace WCF.Migrations
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WCF.Helpers.UnivercityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WCF.Helpers.UnivercityContext context)
        {
            // faculties list
            context.Faculties.AddOrUpdate(f => f.Id,
                new Faculty { Title = "Sciences", Id = 1 },
                new Faculty { Title = "Médecine et Pharmacie", Id = 2 },
                new Faculty { Title = "Economie et Gestion", Id = 3 }
                );

            // sections list
            context.Sections.AddOrUpdate(s => s.Id,
                new Section { Id = 1, FacultyId = 1, Title = "Physique" },
                new Section { Id = 2, FacultyId = 1, Title = "Mathématique" },
                new Section { Id = 3, FacultyId = 1, Title = "Informatique" },
                new Section { Id = 4, FacultyId = 1, Title = "Chimie" },
                new Section { Id = 5, FacultyId = 2, Title = "Médecine" },
                new Section { Id = 6, FacultyId = 2, Title = "Sciences Pharmaceutiques" },
                new Section { Id = 7, FacultyId = 2, Title = "Sciences Biomédicales" },
                new Section { Id = 8, FacultyId = 3, Title = "Sciences de Gestion" },
                new Section { Id = 9, FacultyId = 3, Title = "Sciences Economiques" },
                new Section { Id = 10, FacultyId = 3, Title = "Ingénieur de Gestion" }
                );

            // students list
            context.Students.AddOrUpdate(s => s.Id,
                new Student
                {
                    Name = "Alexander",
                    Surname = "Carson",
                    EnrollmentDate = DateTime.Parse("2010-09-01"),
                    Age = 24,
                    Sex = SexEnum.Man
                },
                new Student
                {
                    Name = "Meredith",
                    Surname = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new Student
                {
                    Name = "Arturo",
                    Surname = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01")
                },
                new Student
                {
                    Name = "Gytis",
                    Surname = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new Student
                {
                    Name = "Yan",
                    Surname = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new Student
                {
                    Name = "Peggy",
                    Surname = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01")
                },
                new Student
                {
                    Name = "Laura",
                    Surname = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01")
                },
                new Student
                {
                    Name = "Nino",
                    Surname = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-08-11")
                },
                new Student
                {
                    Name = "Stefan",
                    Surname = "Aelbrecht",
                    EnrollmentDate = DateTime.Parse("2010-09-01")
                },
                new Student
                {
                    Name = "Eva",
                    Surname = "Aguirre",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new Student
                {
                    Name = "Anna",
                    Surname = "Lucia",
                    EnrollmentDate = DateTime.Parse("2013-09-01")
                },
                new Student
                {
                    Name = "Iva",
                    Surname = "Fejzaj",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new Student
                {
                    Name = "Jessica ",
                    Surname = "Fiorelli",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new Student
                {
                    Name = "Marie",
                    Surname = "Haeverans ",
                    EnrollmentDate = DateTime.Parse("2011-09-01")
                },
                new Student
                {
                    Name = "Laura",
                    Surname = "Hijmans",
                    EnrollmentDate = DateTime.Parse("2013-09-01")
                },
                new Student
                {
                    Name = "Jana ",
                    Surname = "Intini ",
                    EnrollmentDate = DateTime.Parse("2005-08-11")
                }
            );

            // courses list
            var courses = new List<Course>
            {
            new Course{Id=1050,Title="Chemistry",Credits=3,},
            new Course{Id=4022,Title="Microeconomics",Credits=3,},
            new Course{Id=4041,Title="Macroeconomics",Credits=3,},
            new Course{Id=1045,Title="Calculus",Credits=4,},
            new Course{Id=3141,Title="Trigonometry",Credits=4,},
            new Course{Id=2021,Title="Composition",Credits=3,},
            new Course{Id=2042,Title="Literature",Credits=4,}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            context.SaveChanges();
        }
    }
}