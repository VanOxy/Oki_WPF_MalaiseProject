using System.Collections.Generic;

namespace WCF.Model
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // foreign
        public virtual ICollection<Teacher> Teachers { get; set; }

        public virtual int FacultyId { get; set; }
    }
}