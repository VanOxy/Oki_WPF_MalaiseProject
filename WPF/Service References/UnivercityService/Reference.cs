﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF.UnivercityService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WCF")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Student", Namespace="http://schemas.datacontract.org/2004/07/WCF.Model")]
    [System.SerializableAttribute()]
    public partial class Student : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WPF.UnivercityService.Course[] CoursesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CurrentsClassField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EnrollmentDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SectionIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WPF.UnivercityService.SexEnum SexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SurnameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WPF.UnivercityService.Course[] Courses {
            get {
                return this.CoursesField;
            }
            set {
                if ((object.ReferenceEquals(this.CoursesField, value) != true)) {
                    this.CoursesField = value;
                    this.RaisePropertyChanged("Courses");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CurrentsClass {
            get {
                return this.CurrentsClassField;
            }
            set {
                if ((this.CurrentsClassField.Equals(value) != true)) {
                    this.CurrentsClassField = value;
                    this.RaisePropertyChanged("CurrentsClass");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime EnrollmentDate {
            get {
                return this.EnrollmentDateField;
            }
            set {
                if ((this.EnrollmentDateField.Equals(value) != true)) {
                    this.EnrollmentDateField = value;
                    this.RaisePropertyChanged("EnrollmentDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SectionId {
            get {
                return this.SectionIdField;
            }
            set {
                if ((this.SectionIdField.Equals(value) != true)) {
                    this.SectionIdField = value;
                    this.RaisePropertyChanged("SectionId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WPF.UnivercityService.SexEnum Sex {
            get {
                return this.SexField;
            }
            set {
                if ((this.SexField.Equals(value) != true)) {
                    this.SexField = value;
                    this.RaisePropertyChanged("Sex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Surname {
            get {
                return this.SurnameField;
            }
            set {
                if ((object.ReferenceEquals(this.SurnameField, value) != true)) {
                    this.SurnameField = value;
                    this.RaisePropertyChanged("Surname");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Course", Namespace="http://schemas.datacontract.org/2004/07/WCF.Model")]
    [System.SerializableAttribute()]
    public partial class Course : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CreditsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SectionIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WPF.UnivercityService.Student[] StudentsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WPF.UnivercityService.Teacher[] TeachersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Credits {
            get {
                return this.CreditsField;
            }
            set {
                if ((this.CreditsField.Equals(value) != true)) {
                    this.CreditsField = value;
                    this.RaisePropertyChanged("Credits");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SectionId {
            get {
                return this.SectionIdField;
            }
            set {
                if ((this.SectionIdField.Equals(value) != true)) {
                    this.SectionIdField = value;
                    this.RaisePropertyChanged("SectionId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WPF.UnivercityService.Student[] Students {
            get {
                return this.StudentsField;
            }
            set {
                if ((object.ReferenceEquals(this.StudentsField, value) != true)) {
                    this.StudentsField = value;
                    this.RaisePropertyChanged("Students");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WPF.UnivercityService.Teacher[] Teachers {
            get {
                return this.TeachersField;
            }
            set {
                if ((object.ReferenceEquals(this.TeachersField, value) != true)) {
                    this.TeachersField = value;
                    this.RaisePropertyChanged("Teachers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SexEnum", Namespace="http://schemas.datacontract.org/2004/07/WCF.Model")]
    public enum SexEnum : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Man = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Women = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Teacher", Namespace="http://schemas.datacontract.org/2004/07/WCF.Model")]
    [System.SerializableAttribute()]
    public partial class Teacher : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WPF.UnivercityService.Course[] CoursesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WPF.UnivercityService.GradeEnum GradeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WPF.UnivercityService.Section[] SectionsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WPF.UnivercityService.SexEnum SexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SurnameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WPF.UnivercityService.Course[] Courses {
            get {
                return this.CoursesField;
            }
            set {
                if ((object.ReferenceEquals(this.CoursesField, value) != true)) {
                    this.CoursesField = value;
                    this.RaisePropertyChanged("Courses");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WPF.UnivercityService.GradeEnum Grade {
            get {
                return this.GradeField;
            }
            set {
                if ((this.GradeField.Equals(value) != true)) {
                    this.GradeField = value;
                    this.RaisePropertyChanged("Grade");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WPF.UnivercityService.Section[] Sections {
            get {
                return this.SectionsField;
            }
            set {
                if ((object.ReferenceEquals(this.SectionsField, value) != true)) {
                    this.SectionsField = value;
                    this.RaisePropertyChanged("Sections");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WPF.UnivercityService.SexEnum Sex {
            get {
                return this.SexField;
            }
            set {
                if ((this.SexField.Equals(value) != true)) {
                    this.SexField = value;
                    this.RaisePropertyChanged("Sex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Surname {
            get {
                return this.SurnameField;
            }
            set {
                if ((object.ReferenceEquals(this.SurnameField, value) != true)) {
                    this.SurnameField = value;
                    this.RaisePropertyChanged("Surname");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GradeEnum", Namespace="http://schemas.datacontract.org/2004/07/WCF.Model")]
    public enum GradeEnum : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Master = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Doctorat = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Section", Namespace="http://schemas.datacontract.org/2004/07/WCF.Model")]
    [System.SerializableAttribute()]
    public partial class Section : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FacultyIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WPF.UnivercityService.Teacher[] TeachersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FacultyId {
            get {
                return this.FacultyIdField;
            }
            set {
                if ((this.FacultyIdField.Equals(value) != true)) {
                    this.FacultyIdField = value;
                    this.RaisePropertyChanged("FacultyId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WPF.UnivercityService.Teacher[] Teachers {
            get {
                return this.TeachersField;
            }
            set {
                if ((object.ReferenceEquals(this.TeachersField, value) != true)) {
                    this.TeachersField = value;
                    this.RaisePropertyChanged("Teachers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UnivercityService.IUnivercityService")]
    public interface IUnivercityService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUnivercityService/GetData", ReplyAction="http://tempuri.org/IUnivercityService/GetDataResponse")]
        string GetData(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUnivercityService/GetData", ReplyAction="http://tempuri.org/IUnivercityService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUnivercityService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IUnivercityService/GetDataUsingDataContractResponse")]
        WPF.UnivercityService.CompositeType GetDataUsingDataContract(WPF.UnivercityService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUnivercityService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IUnivercityService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<WPF.UnivercityService.CompositeType> GetDataUsingDataContractAsync(WPF.UnivercityService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUnivercityService/AddStudent", ReplyAction="http://tempuri.org/IUnivercityService/AddStudentResponse")]
        bool AddStudent(WPF.UnivercityService.Student student);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUnivercityService/AddStudent", ReplyAction="http://tempuri.org/IUnivercityService/AddStudentResponse")]
        System.Threading.Tasks.Task<bool> AddStudentAsync(WPF.UnivercityService.Student student);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUnivercityService/AddTeacher", ReplyAction="http://tempuri.org/IUnivercityService/AddTeacherResponse")]
        bool AddTeacher(WPF.UnivercityService.Teacher prof);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUnivercityService/AddTeacher", ReplyAction="http://tempuri.org/IUnivercityService/AddTeacherResponse")]
        System.Threading.Tasks.Task<bool> AddTeacherAsync(WPF.UnivercityService.Teacher prof);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUnivercityServiceChannel : WPF.UnivercityService.IUnivercityService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UnivercityServiceClient : System.ServiceModel.ClientBase<WPF.UnivercityService.IUnivercityService>, WPF.UnivercityService.IUnivercityService {
        
        public UnivercityServiceClient() {
        }
        
        public UnivercityServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UnivercityServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UnivercityServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UnivercityServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(string value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(string value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public WPF.UnivercityService.CompositeType GetDataUsingDataContract(WPF.UnivercityService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<WPF.UnivercityService.CompositeType> GetDataUsingDataContractAsync(WPF.UnivercityService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public bool AddStudent(WPF.UnivercityService.Student student) {
            return base.Channel.AddStudent(student);
        }
        
        public System.Threading.Tasks.Task<bool> AddStudentAsync(WPF.UnivercityService.Student student) {
            return base.Channel.AddStudentAsync(student);
        }
        
        public bool AddTeacher(WPF.UnivercityService.Teacher prof) {
            return base.Channel.AddTeacher(prof);
        }
        
        public System.Threading.Tasks.Task<bool> AddTeacherAsync(WPF.UnivercityService.Teacher prof) {
            return base.Channel.AddTeacherAsync(prof);
        }
    }
}
