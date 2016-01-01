using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Message;
using WPF.Messages;
using WPF.Model;

namespace WPF.ViewModel
{
    public class StudentsViewModel : ViewModelBase
    {
        public StudentsViewModel()
        {
            // assign commands
            ChangeToMainPageCommand = new RelayCommand(ChangeToMainPage);
            AddStudentCommand = new RelayCommand<Student>(AddStudent);
            RemoveStudentCommand = new RelayCommand<Student>(DeleteStudent);
            ModifyStudentCommand = new RelayCommand<Student>(ModifyStudent);

            // messages
            Messenger.Default.Register<StudentStateMessage>(this, ModifyStudent_FromView);

            // collections
            DynamicCollection = new ObservableCollection<Student>();
            UsersCollection = new ObservableCollection<Student>();
            _selectedUser = new Student();
            _newUser = new Student();

            // test
            FillCollection();
            FillUserPropertiesCollection(DynamicCollection.First());
        }

        #region Commands

        public RelayCommand<Student> AddStudentCommand { get; set; }
        public RelayCommand<Student> RemoveStudentCommand { get; set; }
        public RelayCommand<Student> ModifyStudentCommand { get; set; }

        #endregion Commands

        #region Data - UI/Bindings

        public ObservableCollection<Student> DynamicCollection { get; set; }
        public ObservableCollection<string> UserProperties { get; set; }
        public ObservableCollection<Student> UsersCollection { get; set; }

        private Student _selectedUser;

        public Student SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    if (value != null) SelectedSexEnum = value.Sex; // SexEnum affectation 4 binding
                    RaisePropertyChanged("SelectedUser");
                }
            }
        }

        private Student _newUser;

        public Student NewUser
        {
            get { return _newUser; }
            set
            {
                if (_newUser != value)
                {
                    _newUser = value;
                    RaisePropertyChanged("NewUser");
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

        #endregion Data - UI/Bindings

        #region CRUD

        private void AddStudent(Student std)
        {
            if (std != null)
                throw new NotImplementedException();
        }

        private void ModifyStudent(Student std)
        {
            if (std != null)
            {
                Messenger.Default.Send(new ModifyStudentMessage(std.StudentId));
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
                            Thread.Sleep(750);
                            _counter--;
                        }
                        else
                        {
                            SearchAndFillDynamicCollection();
                            _timeOut = true;
                            Messenger.Default.Send(new ProgressRingMessage(false));
                        }
                    }
                }
                _counter = 2;
            });
        }

        /// <summary>
        /// Method which will perform a research based on what user enter into Searchbox
        /// and what parameter he wants to search.
        /// </summary>
        private void SearchAndFillDynamicCollection()
        {
            if (_searchTextbox == "")
            {
                App.Current.Dispatcher.Invoke((Action)(() =>
                {
                    DynamicCollection.Clear();
                    foreach (var item in UsersCollection)
                    {
                        DynamicCollection.Add(item);
                    }
                }));
            }
            else
            {
                App.Current.Dispatcher.Invoke((Action)(() =>
                {
                    DynamicCollection.Clear();
                }));

                // text entré par user à chrecher
                var userEntry = _searchTextbox;
                // par rapport à quoi chercher
                var criteria = _searchCriteria;

                string value = UsersCollection[0].GetValue(criteria);

                App.Current.Dispatcher.Invoke((Action)(() =>
                {
                    foreach (var item in UsersCollection)
                    {
                        if (item.GetValue(criteria).Contains(userEntry))
                            DynamicCollection.Add(item);
                    }
                }));
            }
        }

        /// <summary>
        /// Remplit la collection UserProperties avec les noms des proprietes du type User.
        /// Pour en suite binder cette liste au checkbox assicié à la recherche dans DataGrid.
        /// </summary>
        private void FillUserPropertiesCollection(object obj)
        {
            UserProperties = new ObservableCollection<string>();

            var propertiesList = obj.GetType().GetProperties().ToList();

            propertiesList.ForEach(property =>
            {
                UserProperties.Add(property.Name);
            });

            _searchCriteria = propertiesList[1].Name;
        }

        #endregion Search

        #region Navigation

        public ICommand ChangeToMainPageCommand { get; set; }

        private void ChangeToMainPage()
        {
            Messenger.Default.Send(new ChangePageMessage("main"));
        }

        #endregion Navigation

        /// <summary>
        /// Test purposes --> delete at the end !!!!! ************************************
        /// </summary>
        private void FillCollection()
        {
            Random rand = new Random();
            string str = "abcdifghjklmnoprstuwyxzejqsfkuagvcqlkueazygazrazpoizetubxwkfjhvwcdsqfglzerushdfvsd";
            int longueur = str.Length;
            StringBuilder userName = new StringBuilder();
            StringBuilder userSurname = new StringBuilder();
            SexEnum sex;

            for (int i = 1; i < 100; i++)
            {
                // set userName
                userName.Clear();
                for (int j = 0; j < 10; j++)
                {
                    userName.Append(str[rand.Next(0, longueur)]);
                }

                // set userSurname
                userSurname.Clear();
                for (int k = 0; k < 10; k++)
                {
                    userSurname.Append(str[rand.Next(0, longueur)]);
                }

                // set Sex
                if (i % 3 == 0)
                    sex = SexEnum.Women;
                else
                    sex = SexEnum.Man;

                UsersCollection.Add(new Student()
                {
                    StudentId = i + rand.Next(0, 500),
                    Age = rand.Next(17, 40),
                    Name = userName.ToString(),
                    Surname = userSurname.ToString(),
                    Sex = sex,
                    EnrollmentDate = DateTime.Now,
                    CurrentsClass = rand.Next(1, 5)
                });
            }

            foreach (var item in UsersCollection)
                DynamicCollection.Add(item);
        }
    }
}