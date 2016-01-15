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
        public string GetData(string value)
        {
            return string.Format("Service answered: {0}", value);
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

        public bool AddTeacher(Teacher teacher)
        {
            using (var db = new UnivercityContext())
            {
                try
                {
                    db.Teachers.Add(new Teacher()
                    {
                        Name = teacher.Name,
                        Age = teacher.Age,
                        Grade = teacher.Grade
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
    }
}