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
using System.Windows.Threading;
using WPF.Message;
using WPF.Messages;

namespace WPF.ViewModel
{
    public enum SexEnum
    {
        Man,
        Women
    }

    public class User
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public SexEnum Sex { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int CurrentsClass { get; set; }

        public string GetValue(string inputPropertyName)
        {
            string propertyName = inputPropertyName.ToLower();
            string propertyValue = "";
            switch (propertyName)
            {
                case "studentid":
                    propertyValue = StudentId.ToString();
                    break;

                case "name":
                    propertyValue = Name.ToString();
                    break;

                case "age":
                    propertyValue = Age.ToString();
                    break;

                case "sex":
                    propertyValue = Sex.ToString();
                    break;

                case "enrollmentdate":
                    propertyValue = EnrollmentDate.ToString();
                    break;

                case "currentsclass":
                    propertyValue = CurrentsClass.ToString();
                    break;

                default:
                    break;
            }
            return propertyValue;
        }
    }

    public class StudentsViewModel : ViewModelBase
    {
        public StudentsViewModel()
        {
            // assign commands
            ChangeToMainPageCommand = new RelayCommand(ChangeToMainPage);
            AddStudentCommand = new RelayCommand<User>(AddStudent);
            RemoveStudentCommand = new RelayCommand<User>(DeleteStudent);
            ModifyStudentCommand = new RelayCommand<User>(ModifyStudent);

            // collections
            DynamicCollection = new ObservableCollection<User>();
            UsersCollection = new ObservableCollection<User>();
            _selectedUser = new User();
            _newUser = new User();

            // test
            FillCollection();
            FillUserPropertiesCollection(DynamicCollection.First());
        }

        #region Commands

        public RelayCommand<User> AddStudentCommand { get; set; }
        public RelayCommand<User> RemoveStudentCommand { get; set; }
        public RelayCommand<User> ModifyStudentCommand { get; set; }

        #endregion Commands

        #region Data

        public ObservableCollection<User> DynamicCollection { get; set; }
        public ObservableCollection<string> UserProperties { get; set; }
        public ObservableCollection<User> UsersCollection { get; set; }

        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    RaisePropertyChanged("SelectedUser");
                }
            }
        }

        private User _newUser;

        public User NewUser
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

        #endregion Data

        #region CRUD

        private void AddStudent(User std)
        {
            if (std != null)
                throw new NotImplementedException();
        }

        private void ModifyStudent(User std)
        {
        }

        private void DeleteStudent(User std)
        {
            if (std != null)
                DynamicCollection.Remove(std);
        }

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

                UsersCollection.Add(new User()
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

        private void test<TypeOfValue>(string criteria, TypeOfValue list)
        {
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
    }
}