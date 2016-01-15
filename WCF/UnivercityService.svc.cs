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

        public bool AddStudent(Student student)
        {
            using (var db = new UnivercityContext())
            {
                try
                {
                    db.Students.Add(new Student()
                    {
                        Name = student.Name,
                        Surname = student.Surname,
                        Age = student.Age,
                        Sex = student.Sex,
                        SectionId = student.SectionId,
                        CurrentsClass = student.CurrentsClass,
                        EnrollmentDate = student.EnrollmentDate
                    });
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool GetStudentsList()
        {
            throw new NotImplementedException();
        }

        public bool DeleteStudent(int StudentId)
        {
            throw new NotImplementedException();
        }

        public bool ModifyStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public bool GetTeachersList()
        {
            throw new NotImplementedException();
        }

        public bool GetCoursesList()
        {
            throw new NotImplementedException();
        }

        public bool GetFacultiesList()
        {
            throw new NotImplementedException();
        }

        public bool GetSectionsList()
        {
            throw new NotImplementedException();
        }
    }
}