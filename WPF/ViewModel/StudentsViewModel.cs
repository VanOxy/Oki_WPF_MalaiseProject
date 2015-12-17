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

namespace WPF.ViewModel
{
    public class User
    {
        public int Age { get; set; }
        public string Name { get; set; }
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
            for (int i = 12; i < 50; i++)
            {
                UsersCollection.Add(new User()
                {
                    Age = i,
                    Name = "name " + i
                });
            }

            foreach (var item in UsersCollection)
                DynamicCollection.Add(item);
        }

        #endregion CRUD

        #region Search

        private bool _timeOut = true;
        private int _counter = 2;
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

                var query = from u in UsersCollection
                            where u.Name.Contains(_searchTextbox)
                            select u;

                var tempList = query.ToList();

                App.Current.Dispatcher.Invoke((Action)(() =>
                {
                    foreach (var item in tempList)
                    {
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

            _searchCriteria = propertiesList.First().Name;
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