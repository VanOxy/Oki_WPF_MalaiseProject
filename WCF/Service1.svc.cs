using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.Helpers;
using WCF.Model;

namespace WCF
{
    public class Service1 : IService1
    {
        public string GetData(string value)
        {
            return string.Format("Service answered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
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
                        Age = student.Age,
                        Sex = student.Sex,
                        SectionId = student.SectionId,
                        Courses = student.Courses,
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

        public bool AddTeacher(Teacher prof)
        {
            using (var db = new UnivercityContext())
            {
                try
                {
                    db.Teachers.Add(new Teacher()
                    {
                        Name = "Test Teacher",
                        Age = 42,
                        Grade = "Doc"
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
    }
}