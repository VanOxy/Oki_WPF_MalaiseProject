using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WCF.Model;

namespace WCF.Helpers
{
    public class UnivercityContext : DbContext
    {
        public UnivercityContext() : base("Univercity")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}