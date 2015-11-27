using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Model
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        //foreign
        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }

        public virtual int SectionId { get; set; }
    }
}