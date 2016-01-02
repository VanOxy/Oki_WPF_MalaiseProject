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
                new Faculty { Title = "M�decine et Pharmacie", Id = 2 },
                new Faculty { Title = "Economie et Gestion", Id = 3 }
            );

            // sections list
            context.Sections.AddOrUpdate(s => s.Id,
                new Section { Id = 1, FacultyId = 1, Title = "Physique" },
                new Section { Id = 2, FacultyId = 1, Title = "Math�matique" },
                new Section { Id = 3, FacultyId = 1, Title = "Informatique" },
                new Section { Id = 5, FacultyId = 2, Title = "M�decine" },
                new Section { Id = 6, FacultyId = 2, Title = "Sciences Pharmaceutiques" },
                new Section { Id = 7, FacultyId = 2, Title = "Sciences Biom�dicales" },
                new Section { Id = 8, FacultyId = 3, Title = "Sciences de Gestion" },
                new Section { Id = 9, FacultyId = 3, Title = "Sciences Economiques" },
                new Section { Id = 10, FacultyId = 3, Title = "Ing�nieur de Gestion" }
            );

            // courses list
            context.Courses.AddOrUpdate(c => c.Id,
                // sections 8/9/10 - economics/etc
                new Course { Id = 1, Title = "Comptabilit� g�g�rale", Credits = 6, SectionId = 8 },
                new Course { Id = 2, Title = "Economie politique", Credits = 4, SectionId = 9 },
                new Course { Id = 3, Title = "Statistiques", Credits = 7, SectionId = 8 },
                new Course { Id = 4, Title = "M�thodes quantitatives", Credits = 5, SectionId = 9 },
                new Course { Id = 5, Title = "Sociologie", Credits = 4, SectionId = 8 },
                new Course { Id = 6, Title = "Informatique", Credits = 4, SectionId = 10 },
                new Course { Id = 7, Title = "Anglais", Credits = 5, SectionId = 9 },
                new Course { Id = 8, Title = "Micro�conomie", Credits = 4, SectionId = 10 },
                new Course { Id = 9, Title = "Macro�conomie", Credits = 4, SectionId = 10 },
                new Course { Id = 10, Title = "Marketing", Credits = 4, SectionId = 8 },
                new Course { Id = 11, Title = "Management", Credits = 4, SectionId = 8 },
                new Course { Id = 12, Title = "Finances", Credits = 6, SectionId = 9 },
                new Course { Id = 13, Title = "Math�matiques Appliqu�es � la gestion", Credits = 10, SectionId = 10 },
                // section 2 - math
                new Course { Id = 14, Title = "Alg�bre", Credits = 9, SectionId = 2 },
                new Course { Id = 15, Title = "Alg�bre lin�aire et g�ometrie", Credits = 6, SectionId = 2 },
                new Course { Id = 16, Title = "Analyse complexe", Credits = 4, SectionId = 2 },
                new Course { Id = 17, Title = "Probabilit�s et Statistique", Credits = 3, SectionId = 2 },
                // section 1 - phys
                new Course { Id = 18, Title = "Physique g�n�rale", Credits = 11, SectionId = 1 },
                new Course { Id = 19, Title = "Astronomie", Credits = 3, SectionId = 1 },
                new Course { Id = 20, Title = "Physiqe nucl�aire", Credits = 8, SectionId = 1 },
                new Course { Id = 21, Title = "Th�rmodynamique", Credits = 5, SectionId = 1 },
                // section 3 - info
                new Course { Id = 22, Title = "Fonctionnement des ordinateurs", Credits = 5, SectionId = 3 },
                new Course { Id = 23, Title = "Math�matiques �l�mentaires", Credits = 4, SectionId = 3 },
                new Course { Id = 24, Title = "Programmation et Algorithmique", Credits = 9, SectionId = 3 },
                new Course { Id = 25, Title = "Bases de donn�es", Credits = 8, SectionId = 3 },
                // section 5/6/7 - medecine/pharma/biomed
                new Course { Id = 26, Title = "Immunologie", Credits = 2, SectionId = 5 },
                new Course { Id = 27, Title = "Anatomie des membres", Credits = 4, SectionId = 5 },
                new Course { Id = 28, Title = "G�n�tique m�dicale", Credits = 6, SectionId = 5 },
                new Course { Id = 29, Title = "Chimie g�n�rale", Credits = 9, SectionId = 7 },
                new Course { Id = 30, Title = "Biologie cellulaire", Credits = 3, SectionId = 7 },
                new Course { Id = 31, Title = "Toxicologie", Credits = 3, SectionId = 7 },
                new Course { Id = 32, Title = "Chimie organique", Credits = 7, SectionId = 6 },
                new Course { Id = 33, Title = "Biologie mol�culaire", Credits = 5, SectionId = 6 },
                new Course { Id = 34, Title = "Splanchnologie", Credits = 3, SectionId = 6 }
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

            context.SaveChanges();
        }
    }
}