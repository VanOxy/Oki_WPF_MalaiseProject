namespace WCF.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WCF.DAO.UnivercityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Methodé qui permet remplir la DB avec des dpnnées de test
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(WCF.DAO.UnivercityContext context)
        {
            // faculties list
            context.Faculties.AddOrUpdate(f => f.Id,
                new Faculty { Title = "Sciences", Id = 1 },
                new Faculty { Title = "Médecine et Pharmacie", Id = 2 },
                new Faculty { Title = "Economie et Gestion", Id = 3 }
            );

            // sections list
            context.Sections.AddOrUpdate(s => s.Title,
                new Section { Id = 1, FacultyId = 1, Title = "Physique" },
                new Section { Id = 2, FacultyId = 1, Title = "Mathématique" },
                new Section { Id = 3, FacultyId = 1, Title = "Informatique" },
                new Section { Id = 5, FacultyId = 2, Title = "Médecine" },
                new Section { Id = 6, FacultyId = 2, Title = "Sciences Pharmaceutiques" },
                new Section { Id = 7, FacultyId = 2, Title = "Sciences Biomédicales" },
                new Section { Id = 8, FacultyId = 3, Title = "Sciences de Gestion" },
                new Section { Id = 9, FacultyId = 3, Title = "Sciences Economiques" },
                new Section { Id = 10, FacultyId = 3, Title = "Ingénieur de Gestion" }
            );

            // courses list
            context.Courses.AddOrUpdate(c => c.Id,
                // sections 8/9/10 - economics/etc
                new Course { Id = 1, Title = "Comptabilité gégérale", Credits = 6, SectionId = 8 },
                new Course { Id = 2, Title = "Economie politique", Credits = 4, SectionId = 9 },
                new Course { Id = 3, Title = "Statistiques", Credits = 7, SectionId = 8 },
                new Course { Id = 4, Title = "Méthodes quantitatives", Credits = 5, SectionId = 9 },
                new Course { Id = 5, Title = "Sociologie", Credits = 4, SectionId = 8 },
                new Course { Id = 6, Title = "Informatique", Credits = 4, SectionId = 10 },
                new Course { Id = 7, Title = "Anglais", Credits = 5, SectionId = 9 },
                new Course { Id = 8, Title = "Microéconomie", Credits = 4, SectionId = 10 },
                new Course { Id = 9, Title = "Macroéconomie", Credits = 4, SectionId = 10 },
                new Course { Id = 10, Title = "Marketing", Credits = 4, SectionId = 8 },
                new Course { Id = 11, Title = "Management", Credits = 4, SectionId = 8 },
                new Course { Id = 12, Title = "Finances", Credits = 6, SectionId = 9 },
                new Course { Id = 13, Title = "Mathématiques Appliquées à la gestion", Credits = 10, SectionId = 10 },
                // section 2 - math
                new Course { Id = 14, Title = "Algèbre", Credits = 9, SectionId = 2 },
                new Course { Id = 15, Title = "Algèbre linèaire et géometrie", Credits = 6, SectionId = 2 },
                new Course { Id = 16, Title = "Analyse complexe", Credits = 4, SectionId = 2 },
                new Course { Id = 17, Title = "Probabilités et Statistique", Credits = 3, SectionId = 2 },
                // section 1 - phys
                new Course { Id = 18, Title = "Physique générale", Credits = 11, SectionId = 1 },
                new Course { Id = 19, Title = "Astronomie", Credits = 3, SectionId = 1 },
                new Course { Id = 20, Title = "Physiqe nucléaire", Credits = 8, SectionId = 1 },
                new Course { Id = 21, Title = "Thérmodynamique", Credits = 5, SectionId = 1 },
                // section 3 - info
                new Course { Id = 22, Title = "Fonctionnement des ordinateurs", Credits = 5, SectionId = 3 },
                new Course { Id = 23, Title = "Mathématiques élémentaires", Credits = 4, SectionId = 3 },
                new Course { Id = 24, Title = "Programmation et Algorithmique", Credits = 9, SectionId = 3 },
                new Course { Id = 25, Title = "Bases de données", Credits = 8, SectionId = 3 },
                // section 5/6/7 - medecine/pharma/biomed
                new Course { Id = 26, Title = "Immunologie", Credits = 2, SectionId = 5 },
                new Course { Id = 27, Title = "Anatomie des membres", Credits = 4, SectionId = 5 },
                new Course { Id = 28, Title = "Génétique médicale", Credits = 6, SectionId = 5 },
                new Course { Id = 29, Title = "Chimie générale", Credits = 9, SectionId = 7 },
                new Course { Id = 30, Title = "Biologie cellulaire", Credits = 3, SectionId = 7 },
                new Course { Id = 31, Title = "Toxicologie", Credits = 3, SectionId = 7 },
                new Course { Id = 32, Title = "Chimie organique", Credits = 7, SectionId = 6 },
                new Course { Id = 33, Title = "Biologie moléculaire", Credits = 5, SectionId = 6 },
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
                    Sex = SexEnum.Man,
                    CurrentClass = 3,
                    SectionId = 1
                },
                new Student
                {
                    Name = "Meredith",
                    Surname = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01"),
                    Age = 22,
                    Sex = SexEnum.Man,
                    CurrentClass = 1,
                    SectionId = 2
                },
                new Student
                {
                    Name = "Arturo",
                    Surname = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01"),
                    Age = 21,
                    Sex = SexEnum.Man,
                    CurrentClass = 1,
                    SectionId = 3
                },
                new Student
                {
                    Name = "Gytis",
                    Surname = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01"),
                    Age = 24,
                    Sex = SexEnum.Man,
                    CurrentClass = 3,
                    SectionId = 4
                },
                new Student
                {
                    Name = "Yan",
                    Surname = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01"),
                    Age = 27,
                    Sex = SexEnum.Man,
                    CurrentClass = 4,
                    SectionId = 5
                },
                new Student
                {
                    Name = "Peggy",
                    Surname = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01"),
                    Age = 25,
                    Sex = SexEnum.Women,
                    CurrentClass = 3,
                    SectionId = 6
                },
                new Student
                {
                    Name = "Laura",
                    Surname = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01"),
                    Age = 24,
                    Sex = SexEnum.Women,
                    CurrentClass = 2,
                    SectionId = 7
                },
                new Student
                {
                    Name = "Nino",
                    Surname = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-08-11"),
                    Age = 26,
                    Sex = SexEnum.Man,
                    CurrentClass = 6,
                    SectionId = 8
                },
                new Student
                {
                    Name = "Stefan",
                    Surname = "Aelbrecht",
                    EnrollmentDate = DateTime.Parse("2010-09-01"),
                    Age = 24,
                    Sex = SexEnum.Man,
                    CurrentClass = 4,
                    SectionId = 9
                },
                new Student
                {
                    Name = "Eva",
                    Surname = "Aguirre",
                    EnrollmentDate = DateTime.Parse("2012-09-01"),
                    Age = 23,
                    Sex = SexEnum.Women,
                    CurrentClass = 3,
                    SectionId = 10
                },
                new Student
                {
                    Name = "Anna",
                    Surname = "Lucia",
                    EnrollmentDate = DateTime.Parse("2013-09-01"),
                    Age = 25,
                    Sex = SexEnum.Women,
                    CurrentClass = 2,
                    SectionId = 1
                },
                new Student
                {
                    Name = "Iva",
                    Surname = "Fejzaj",
                    EnrollmentDate = DateTime.Parse("2012-09-01"),
                    Age = 19,
                    Sex = SexEnum.Women,
                    CurrentClass = 2,
                    SectionId = 2
                },
                new Student
                {
                    Name = "Jessica ",
                    Surname = "Fiorelli",
                    EnrollmentDate = DateTime.Parse("2012-09-01"),
                    Age = 22,
                    Sex = SexEnum.Women,
                    CurrentClass = 3,
                    SectionId = 3
                },
                new Student
                {
                    Name = "Marie",
                    Surname = "Haeverans ",
                    EnrollmentDate = DateTime.Parse("2011-09-01"),
                    Age = 24,
                    Sex = SexEnum.Women,
                    CurrentClass = 3,
                    SectionId = 4
                },
                new Student
                {
                    Name = "Laura",
                    Surname = "Hijmans",
                    EnrollmentDate = DateTime.Parse("2013-09-01"),
                    Age = 21,
                    Sex = SexEnum.Women,
                    CurrentClass = 4,
                    SectionId = 5
                },
                new Student
                {
                    Name = "Jana ",
                    Surname = "Intini ",
                    EnrollmentDate = DateTime.Parse("2005-08-11"),
                    Age = 28,
                    Sex = SexEnum.Women,
                    CurrentClass = 5,
                    SectionId = 6
                },
                new Student
                {
                    Name = "Erin",
                    Surname = "Baggoti",
                    EnrollmentDate = DateTime.Parse("2010-09-10"),
                    Age = 24,
                    Sex = SexEnum.Women,
                    CurrentClass = 4,
                    SectionId = 7
                },
                new Student
                {
                    Name = "Pablo",
                    Surname = "Balan",
                    EnrollmentDate = DateTime.Parse("2011-09-12"),
                    Age = 23,
                    Sex = SexEnum.Man,
                    CurrentClass = 3,
                    SectionId = 8
                },
                new Student
                {
                    Name = "Jennifer",
                    Surname = "Brea",
                    EnrollmentDate = DateTime.Parse("2012-09-15"),
                    Age = 22,
                    Sex = SexEnum.Women,
                    CurrentClass = 2,
                    SectionId = 9
                },
                new Student
                {
                    Name = "Jonathan",
                    Surname = "Bruno",
                    EnrollmentDate = DateTime.Parse("2013-10-02"),
                    Age = 21,
                    Sex = SexEnum.Man,
                    CurrentClass = 2,
                    SectionId = 10
                }
            );

            context.Teachers.AddOrUpdate(s => s.Id,
                new Teacher()
                {
                    Name = "Kate",
                    Surname = "Aronowitz",
                    Age = 42,
                    Email = "kate.aronovitz@unif.com",
                    Sex = SexEnum.Women,
                    Grade = GradeEnum.Doctorat
                },
                new Teacher()
                {
                    Name = "Ethan",
                    Surname = "Beard",
                    Age = 32,
                    Email = "ethan.beard@unif.com",
                    Sex = SexEnum.Man,
                    Grade = GradeEnum.Master
                },
                new Teacher()
                {
                    Name = "David",
                    Surname = "Fisch",
                    Age = 38,
                    Email = "david.fish@unif.com",
                    Sex = SexEnum.Man,
                    Grade = GradeEnum.Master
                },
                new Teacher()
                {
                    Name = "Paul",
                    Surname = "Adams",
                    Email = "paul.adams@unif.com",
                    Age = 45,
                    Sex = SexEnum.Man,
                    Grade = GradeEnum.Doctorat
                },
                new Teacher()
                {
                    Name = "Cat",
                    Surname = "Lee",
                    Age = 31,
                    Email = "cat.lee@unif.com",
                    Sex = SexEnum.Women,
                    Grade = GradeEnum.Master
                },
                new Teacher()
                {
                    Name = "Rohit",
                    Surname = "Dhawan",
                    Age = 36,
                    Email = "rohit.dhawan@unif.com",
                    Sex = SexEnum.Man,
                    Grade = GradeEnum.Master
                },
                new Teacher()
                {
                    Name = "David",
                    Surname = "Recordon",
                    Age = 41,
                    Email = "david.recordon@unif.com",
                    Sex = SexEnum.Man,
                    Grade = GradeEnum.Doctorat
                },
                new Teacher()
                {
                    Name = "Keith",
                    Surname = "Adams",
                    Age = 35,
                    Email = "keith.adams@unif.com",
                    Sex = SexEnum.Women,
                    Grade = GradeEnum.Master
                },
                new Teacher()
                {
                    Name = "Ross",
                    Surname = "Blake",
                    Age = 48,
                    Email = "ross.blake@unif.com",
                    Sex = SexEnum.Man,
                    Grade = GradeEnum.Master
                },
                new Teacher()
                {
                    Name = "Greg",
                    Surname = "Hoy",
                    Age = 53,
                    Email = "greg.hoy@unif.com",
                    Sex = SexEnum.Man,
                    Grade = GradeEnum.Doctorat
                }
            );

            context.SaveChanges();
        }
    }
}