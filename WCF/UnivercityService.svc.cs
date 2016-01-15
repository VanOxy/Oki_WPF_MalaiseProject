using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
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
                    db.Entry(original).CurrentValues.SetValues(std);
                    db.SaveChanges();
                    return true;
                }

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

        public bool GetTeachersList()
        {
            throw new NotImplementedException();
        }

        #endregion Teachers

        #region Courses

        public bool GetCoursesList()
        {
            throw new NotImplementedException();
        }

        #endregion Courses

        #region Faculties

        public bool GetFacultiesList()
        {
            throw new NotImplementedException();
        }

        #endregion Faculties

        #region Sections

        public bool GetSectionsList()
        {
            throw new NotImplementedException();
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