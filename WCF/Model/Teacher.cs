using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public SexEnum Sex { get; set; }
        public GradeEnum Grade { get; set; }

        // foreigns
        public virtual ICollection<Section> Sections { get; set; }

        public ICollection<Course> Courses { get; set; }
    }

    public enum GradeEnum
    {
        Master,
        Doctorat
    }
}