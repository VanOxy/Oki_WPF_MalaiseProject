using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

            // test
            FillCollection();

            FillUserPropertiesCollection(Collection.First());
        }

        #region Commands

        public RelayCommand<User> AddStudentCommand { get; set; }
        public RelayCommand<User> RemoveStudentCommand { get; set; }
        public RelayCommand<User> ModifyStudentCommand { get; set; }

        #endregion Commands

        #region Data

        public ObservableCollection<User> Collection { get; set; }
        public ObservableCollection<string> UserProperties { get; set; }

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
                Collection.Remove(std);
        }

        /// <summary>
        /// Test purposes --> delete at the end !!!!! ************************************
        /// </summary>
        private void FillCollection()
        {
            Collection = new ObservableCollection<User>();
            for (int i = 12; i < 50; i++)
            {
                Collection.Add(new User()
                {
                    Age = i,
                    Name = "name " + i
                });
            }
        }

        #endregion CRUD

        #region Search

        /// <summary>
        /// Remplit la collection UserProperties avec les noms des proprietes du type User.
        /// Pour en suite binder cette liste au checkbox assicié à la recherche dans DataGrid.
        /// </summary>
        private void FillUserPropertiesCollection(object obj)
        {
            UserProperties = new ObservableCollection<string>();

            obj.GetType().GetProperties().ToList().ForEach(property =>
            {
                UserProperties.Add(property.Name);
            });
        }

        private void PerformResearch()
        {
            throw new NotImplementedException();
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