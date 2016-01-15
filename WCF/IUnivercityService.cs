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
        string GetData(string value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        #region Students

        [OperationContract]
        bool GetStudentsList();

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
    }

    [DataContract]
    public class CompositeType
    {
        private bool boolValue = true;
        private string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}