using System;
using System.Collections.Generic;

namespace WCF.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surame { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int CurrentsClass { get; set; }

        // foreign keys
        public virtual ICollection<Course> Courses { get; set; }

        public virtual int SectionId { get; set; }
    }

    public enum Sex
    {
        Man,
        Women
    }
}