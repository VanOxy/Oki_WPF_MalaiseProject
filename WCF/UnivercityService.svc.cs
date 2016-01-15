using System;
using System.Linq;
using WCF.DAO;
using WCF.Model;

namespace WCF
{
    public class UnivercityService : IUnivercityService
    {
        #region Students

        public StudentsList GetStudentsList()
        {
            using (var db = new UnivercityContext())
            {
                StudentsList list = new StudentsList();

                foreach (var row in db.Students)
                {
                    list.Students.Add(new Student()
                    {
                        Id = row.Id,
                        Name = row.Name,
                        Surname = row.Surname,
                        Sex = row.Sex,
                        Age = row.Age,
                        CurrentClass = row.CurrentClass,
                        EnrollmentDate = row.EnrollmentDate,
                        SectionId = row.SectionId
                    });
                }

                return list;
            }
        }

        public int AddStudent(Student student)
        {
            using (var db = new UnivercityContext())
            {
                try
                {
                    Student newStudent = new Student()
                    {
                        Name = student.Name,
                        Surname = student.Surname,
                        Age = student.Age,
                        Sex = student.Sex,
                        SectionId = student.SectionId,
                        CurrentClass = student.CurrentClass,
                        EnrollmentDate = student.EnrollmentDate
                    };
                    db.Students.Add(newStudent);
                    db.SaveChanges();

                    // while db.saveChanges() newStudent.ID is initialized,
                    // so we can get it after that.
                    return newStudent.Id;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        public bool ModifyStudent(Student std)
        {
            using (var db = new UnivercityContext())
            {
                var original = db.Students.Find(std.Id);

                if (original != null)
                {
                    original.Name = std.Name;
                    original.Surname = std.Surname;
                    original.Age = std.Age;
                    original.CurrentClass = std.CurrentClass;
                    original.EnrollmentDate = std.EnrollmentDate;
                    original.Sex = std.Sex;
                    db.SaveChanges();
                }

                // advanced method, but the problems is that i've not managed sectionId
                // so that it becomes 0 within this method  // todo later --> means UI modif :(

                //if (original != null)
                //{
                //    db.Entry(original).CurrentValues.SetValues(std);
                //    db.SaveChanges();
                //    return true;
                //}

                return false;
            }
        }

        public bool DeleteStudent(int StudentId)
        {
            using (var db = new UnivercityContext())
            {
                var student = new Student { Id = StudentId };
                db.Students.Attach(student);
                db.Students.Remove(student);
                db.SaveChanges();
            }
            return true;
        }

        #endregion Students

        #region Teachers

        public TeachersList GetTeachersList()
        {
            using (var db = new UnivercityContext())
            {
                TeachersList list = new TeachersList();

                foreach (var row in db.Teachers)
                {
                    list.Teachers.Add(new Teacher()
                    {
                        Id = row.Id,
                        Name = row.Name,
                        Surname = row.Surname,
                        Sex = row.Sex,
                        Age = row.Age,
                        Grade = row.Grade,
                        Email = row.Email
                    });
                }

                return list;
            }
        }

        #endregion Teachers

        #region Courses

        public CoursesList GetCoursesList()
        {
            using (var db = new UnivercityContext())
            {
                CoursesList list = new CoursesList();

                foreach (var row in db.Courses)
                {
                    list.Courses.Add(new Course()
                    {
                        Id = row.Id,
                        Title = row.Title,
                        Credits = row.Credits,
                        SectionId = row.SectionId
                    });
                }

                return list;
            }
        }

        #endregion Courses

        #region Faculties

        public FacultiesList GetFacultiesList()
        {
            using (var db = new UnivercityContext())
            {
                FacultiesList list = new FacultiesList();

                foreach (var row in db.Faculties)
                {
                    list.Faculties.Add(new Faculty()
                    {
                        Id = row.Id,
                        Title = row.Title
                    });
                }

                return list;
            }
        }

        #endregion Faculties

        #region Sections

        public SectionsList GetSectionsList()
        {
            using (var db = new UnivercityContext())
            {
                SectionsList list = new SectionsList();

                foreach (var row in db.Sections)
                {
                    list.Sections.Add(new Section()
                    {
                        Id = row.Id,
                        Title = row.Title,
                        FacultyId = row.FacultyId
                    });
                }

                return list;
            }
        }

        #endregion Sections

        #region Utilities

        public bool TryLogin(string email, string password)
        {
            using (var db = new UnivercityContext())
            {
                var query = from t in db.Teachers
                            where t.Email == email && t.Password == password
                            select t;

                if (query.FirstOrDefault() != null)
                    return true;
                else
                    return false;
            }
        }

        public int GetStudentsNumber()
        {
            using (var db = new UnivercityContext())
            {
                return (from s in db.Students select s).Count();
            }
        }

        public int GetTeachersNumber()
        {
            using (var db = new UnivercityContext())
            {
                return (from s in db.Teachers select s).Count();
            }
        }

        public int GetCoursesNumber()
        {
            using (var db = new UnivercityContext())
            {
                return (from s in db.Courses select s).Count();
            }
        }

        public int GetSectionsNumber()
        {
            using (var db = new UnivercityContext())
            {
                return (from s in db.Sections select s).Count();
            }
        }

        public int GetFacultiesNumber()
        {
            using (var db = new UnivercityContext())
            {
                return (from s in db.Faculties select s).Count();
            }
        }

        #endregion Utilities
    }
}