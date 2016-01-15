using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.Model;

namespace WCF
{
    [ServiceContract]
    public interface IUnivercityService
    {
        [OperationContract]
        bool TryLogin(string email, string password);

        #region Students

        [OperationContract]
        StudentsList GetStudentsList();

        [OperationContract]
        bool AddStudent(Student student);

        [OperationContract]
        bool DeleteStudent(int StudentId);

        [OperationContract]
        bool ModifyStudent(Student student);

        #endregion Students

        #region Teachers

        [OperationContract]
        bool GetTeachersList();

        #endregion Teachers

        #region Courses

        [OperationContract]
        bool GetCoursesList();

        #endregion Courses

        #region Faculties

        [OperationContract]
        bool GetFacultiesList();

        #endregion Faculties

        #region Sections

        [OperationContract]
        bool GetSectionsList();

        #endregion Sections

        #region Utilities

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
}