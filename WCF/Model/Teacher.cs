using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Model
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }

        // foreigns
        public virtual ICollection<Section> Sections { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}