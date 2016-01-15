using System;
using System.Collections.Generic;

namespace WCF.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public SexEnum Sex { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int CurrentClass { get; set; }

        // foreign keys
        public virtual ICollection<Course> Courses { get; set; }

        public virtual int SectionId { get; set; }

        public string GetValue(string inputPropertyName)
        {
            string propertyName = inputPropertyName.ToLower();
            string propertyValue = "";
            switch (propertyName)
            {
                case "studentid":
                    propertyValue = Id.ToString();
                    break;

                case "name":
                    propertyValue = Name.ToString();
                    break;

                case "age":
                    propertyValue = Age.ToString();
                    break;

                case "sex":
                    propertyValue = Sex.ToString();
                    break;

                case "enrollmentdate":
                    propertyValue = EnrollmentDate.ToString();
                    break;

                case "currentsclass":
                    propertyValue = CurrentClass.ToString();
                    break;

                default:
                    break;
            }
            return propertyValue;
        }
    }

    public enum SexEnum
    {
        Man,
        Women
    }
}