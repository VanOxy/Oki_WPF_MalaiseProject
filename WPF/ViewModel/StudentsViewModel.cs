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

    public class StudentsViewModel
    {
        public StudentsViewModel()
        {
            // assign commands
            ChangeToMainPageCommand = new RelayCommand(ChangeToMainPage);
            AddStudentCommand = new RelayCommand<User>(AddUser);

            // test
            FillCollection();
        }

        private void AddUser(User user)
        {
            if (user != null)
                Collection.Remove(user);
        }

        #region Commands

        public RelayCommand<User> AddStudentCommand { get; set; }

        #endregion Commands

        #region Data

        public ObservableCollection<User> Collection { get; set; }

        #endregion Data

        #region Methods

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

        #endregion Methods

        #region Navigation

        public ICommand ChangeToMainPageCommand { get; set; }

        private void ChangeToMainPage()
        {
            Messenger.Default.Send(new ChangePageMessage("main"));
        }

        #endregion Navigation
    }
}