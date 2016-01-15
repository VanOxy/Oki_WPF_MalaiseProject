using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Message;
using WPF.Messages;
using WPF.UnivercityService;

namespace WPF.ViewModel
{
    public class StudentsViewModel : ViewModelBase
    {
        public StudentsViewModel()
        {
            // assign commands
            ChangeToMainPageCommand = new RelayCommand(ChangeToMainPage);
            AddStudentCommand = new RelayCommand(AddStudent);
            RemoveStudentCommand = new RelayCommand<Student>(DeleteStudent);
            ModifyStudentCommand = new RelayCommand<Student>(ModifyStudent);

            // messages
            Messenger.Default.Register<StudentStateMessage>(this, ModifyStudent_FromView);

            // collections
            DynamicCollection = new ObservableCollection<Student>();
            StudentsCollection = new ObservableCollection<Student>();
            _selectedStudent = new Student();
            _newStudent = new Student() { EnrollmentDate = DateTime.Today.Date };

            GetStudentsFromService();
            FillUserPropertiesCollection(DynamicCollection.First());
        }

        #region Commands

        public ICommand AddStudentCommand { get; set; }
        public RelayCommand<Student> RemoveStudentCommand { get; set; }
        public RelayCommand<Student> ModifyStudentCommand { get; set; }

        #endregion Commands

        #region Data - UI/Bindings

        public ObservableCollection<Student> DynamicCollection { get; set; }
        public ObservableCollection<string> StudentProperties { get; set; }
        public ObservableCollection<Student> StudentsCollection { get; set; }

        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                if (_selectedStudent != value)
                {
                    _selectedStudent = value;
                    if (value != null) SelectedSexEnum = value.Sex; // SexEnum affectation 4 binding
                    RaisePropertyChanged("SelectedStudent");
                }
            }
        }

        private Student _newStudent;

        public Student NewStudent
        {
            get { return _newStudent; }
            set
            {
                if (_newStudent != value)
                {
                    _newStudent = value;
                    RaisePropertyChanged("NewStudent");
                }
            }
        }

        // Sex enumeration management
        // value is affected in SelectedUser - Setter
        private SexEnum _selectedSexEnum;

        public SexEnum SelectedSexEnum
        {
            get { return _selectedSexEnum; }
            set
            {
                _selectedSexEnum = value;
                RaisePropertyChanged("SelectedSexEnum");
            }
        }

        public IEnumerable<SexEnum> SexEnumValues
        {
            get
            {
                return Enum.GetValues(typeof(SexEnum)).Cast<SexEnum>();
            }
        }

        private string _newStudentErrorMessage = "";

        public string NewStudentErrorMessage
        {
            get { return _newStudentErrorMessage; }
            set
            {
                _newStudentErrorMessage = value;
                RaisePropertyChanged("NewStudentErrorMessage");
            }
        }

        private SexEnum _newSexEnum;

        public SexEnum NewSexEnum
        {
            get { return _newSexEnum; }
            set
            {
                _newSexEnum = value;
                RaisePropertyChanged("NewSexEnum");
            }
        }

        #endregion Data - UI/Bindings

        #region CRUD

        private void GetStudentsFromService()
        {
            StudentsList studentsList;
            using (var service = new UnivercityServiceClient())
            {
                studentsList = service.GetStudentsList();
            }

            foreach (var std in studentsList.Students)
            {
                DynamicCollection.Add(std);
            }
        }

        private void AddStudent()
        {
            Messenger.Default.Send(new ProgressRingMessage(true));
            _newStudentErrorMessage = "";
            if (ValidData())
            {
                Student newStd = new Student()
                {
                    Name = NewStudent.Name,
                    Surname = NewStudent.Surname,
                    Age = NewStudent.Age,
                    Sex = NewSexEnum,
                    EnrollmentDate = NewStudent.EnrollmentDate,
                    CurrentClass = NewStudent.CurrentClass
                };

                using (var service = new UnivercityServiceClient())
                {
                    int id = service.AddStudent(newStd);
                    if (id > 0)
                    {
                        newStd.Id = id;
                        DynamicCollection.Add(newStd);
                        ClearNewStudent();
                    }
                }
            }
            else
            {
                NewStudentErrorMessage = "Wrong Data !!!";
            }
            Messenger.Default.Send(new ProgressRingMessage(false));
        }

        private void ClearNewStudent()
        {
            NewStudent = null;
            NewStudent = new Student() { EnrollmentDate = DateTime.Today.Date };
        }

        private void ModifyStudent(Student std)
        {
            if (std != null)
            {
                Messenger.Default.Send(new ModifyStudentMessage(std.Id));
            }
        }

        private void ModifyStudent_FromView(StudentStateMessage obj)
        {
            throw new NotImplementedException();
        }

        private void DeleteStudent(Student std)
        {
            if (std != null)
                DynamicCollection.Remove(std);
        }

        /// <summary>
        /// method which would validate the user entry
        /// </summary>
        /// <returns></returns>
        private bool ValidData()
        {
            // remarque... comme on est bindé avec param int, si un string entré ça devient un 0
            // d'où le check de la validité age > 0
            int age;
            int currentClass;
            bool validAge = Int32.TryParse(NewStudent.Age.ToString(), out age);
            bool validClass = Int32.TryParse(NewStudent.CurrentClass.ToString(), out currentClass);

            if (currentClass > 0 && currentClass <= 5 && age > 0)
                return true;
            else
                return false;
        }

        #endregion CRUD

        #region Search

        private int _counter = 2;
        private bool _timeOut = true;

        private string _searchTextbox = "";

        public string SearchTextbox
        {
            get { return _searchTextbox; }
            set
            {
                if (value != _searchTextbox)
                {
                    _searchTextbox = value;
                    RaisePropertyChanged("SearchTextbox");

                    PerformResearch();
                }
            }
        }

        private string _searchCriteria;

        public string SearchCriteria
        {
            get { return _searchCriteria; }
            set
            {
                if (_searchCriteria != value)
                {
                    _searchCriteria = value;
                    RaisePropertyChanged("SearchCriteria");
                }
            }
        }

        private void PerformResearch()
        {
            // algo pout faire un delai après que l'user aie tapé le txt dans la search box.
            // Et eviter de refaire le tri à chaque capture d'event
            Task.Run(() =>
            {
                if (_timeOut)
                {
                    _timeOut = false;
                    Messenger.Default.Send(new ProgressRingMessage(true));

                    while (!_timeOut)
                    {
                        if (_counter != 0)
                        {
                            Thread.Sleep(350);
                            _counter--;
                        }
                        else
                        {
                            //SearchAndFillDynamicCollection();
                            _timeOut = true;
                            Messenger.Default.Send(new ProgressRingMessage(false));
                        }
                    }
                }
                _counter = 2;
            });
        }

        // <summary>
        // Method which will perform a research based on what user enter into Searchbox
        // and what parameter he wants to search.
        // </summary>

        //private void SearchAndFillDynamicCollection()
        //{
        //    if (_searchTextbox == "")
        //    {
        //        App.Current.Dispatcher.Invoke((Action)(() =>
        //        {
        //            DynamicCollection.Clear();
        //            foreach (var item in StudentsCollection)
        //            {
        //                DynamicCollection.Add(item);
        //            }
        //        }));
        //    }
        //    else
        //    {
        //        App.Current.Dispatcher.Invoke((Action)(() =>
        //        {
        //            DynamicCollection.Clear();
        //        }));

        //        // text entré par user à chrecher
        //        var userEntry = _searchTextbox;
        //        // par rapport à quoi chercher
        //        var criteria = _searchCriteria;

        //        //string value = UsersCollection[0].GetValue(criteria);

        //        App.Current.Dispatcher.Invoke((Action)(() =>
        //        {
        //            foreach (var item in StudentsCollection)
        //            {
        //                if (item.GetValue(criteria).Contains(userEntry))
        //                    DynamicCollection.Add(item);
        //            }
        //        }));
        //    }
        //}

        /// <summary>
        /// Remplit la collection UserProperties avec les noms des proprietes du type User.
        /// Pour en suite binder cette liste au checkbox assicié à la recherche dans DataGrid.
        /// </summary>
        private void FillUserPropertiesCollection(object obj)
        {
            StudentProperties = new ObservableCollection<string>();

            //var propertiesList = obj.GetType().GetProperties().ToList();

            //propertiesList.ForEach(property =>
            //{
            //    StudentProperties.Add(property.Name);
            //});

            StudentProperties.Add("Id");
            StudentProperties.Add("Name");
            StudentProperties.Add("Surname");
            StudentProperties.Add("Age");
            StudentProperties.Add("Sex");
            StudentProperties.Add("Enrollement Date");
            StudentProperties.Add("Current Class");

            _searchCriteria = StudentProperties[1];
        }

        #endregion Search

        #region Navigation

        public ICommand ChangeToMainPageCommand { get; set; }

        private void ChangeToMainPage()
        {
            Messenger.Default.Send(new ChangePageMessage("main"));
        }

        #endregion Navigation
    }
}