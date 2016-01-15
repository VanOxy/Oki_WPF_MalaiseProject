using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using WCF.Model;

namespace WCF
{
    [ServiceContract]
    public interface IUnivercityService
    {
        #region Students

        [OperationContract]
        StudentsList GetStudentsList();

        [OperationContract]
        int AddStudent(Student student);

        [OperationContract]
        bool DeleteStudent(int StudentId);

        [OperationContract]
        bool ModifyStudent(Student student);

        #endregion Students

        #region Teachers

        [OperationContract]
        TeachersList GetTeachersList();

        #endregion Teachers

        #region Courses

        [OperationContract]
        CoursesList GetCoursesList();

        #endregion Courses

        #region Faculties

        [OperationContract]
        FacultiesList GetFacultiesList();

        #endregion Faculties

        #region Sections

        [OperationContract]
        SectionsList GetSectionsList();

        #endregion Sections

        #region Utilities

        [OperationContract]
        bool TryLogin(string email, string password);

        [OperationContract]
        int GetStudentsNumber();

        [OperationContract]
        int GetTeachersNumber();

        [OperationContract]
        int GetCoursesNumber();

        [OperationContract]
        int GetSectionsNumber();

        [OperationContract]
        int GetFacultiesNumber();

        #endregion Utilities
    }

    [DataContract]
    [Serializable]
    public class StudentsList
    {
        private List<Student> _students;

        public StudentsList()
        {
            _students = new List<Student>();
        }

        [DataMember]
        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }
    }

    [DataContract]
    [Serializable]
    public class TeachersList
    {
        private List<Teacher> _teachers;

        public TeachersList()
        {
            _teachers = new List<Teacher>();
        }

        [DataMember]
        public List<Teacher> Teachers
        {
            get { return _teachers; }
            set { _teachers = value; }
        }
    }

    [DataContract]
    [Serializable]
    public class CoursesList
    {
        private List<Course> _courses;

        public CoursesList()
        {
            _courses = new List<Course>();
        }

        [DataMember]
        public List<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }
    }

    [DataContract]
    [Serializable]
    public class FacultiesList
    {
        private List<Faculty> _faculties;

        public FacultiesList()
        {
            _faculties = new List<Faculty>();
        }

        [DataMember]
        public List<Faculty> Faculties
        {
            get { return _faculties; }
            set { _faculties = value; }
        }
    }

    [DataContract]
    [Serializable]
    public class SectionsList
    {
        private List<Section> _sections;

        public SectionsList()
        {
            _sections = new List<Section>();
        }

        [DataMember]
        public List<Section> Sections
        {
            get { return _sections; }
            set { _sections = value; }
        }
    }
}