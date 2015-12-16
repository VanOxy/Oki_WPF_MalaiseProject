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
            AddStudentCommand = new RelayCommand<User>(AddStudent);
            RemoveStudentCommand = new RelayCommand<User>(DeleteStudent);
            ModifyStudentCommand = new RelayCommand<User>(ModifyStudent);

            // test
            FillCollection();
        }

        #region Commands

        public RelayCommand<User> AddStudentCommand { get; set; }
        public RelayCommand<User> RemoveStudentCommand { get; set; }
        public RelayCommand<User> ModifyStudentCommand { get; set; }

        #endregion Commands

        #region Data

        public ObservableCollection<User> Collection { get; set; }

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

        #region Navigation

        public ICommand ChangeToMainPageCommand { get; set; }

        private void ChangeToMainPage()
        {
            Messenger.Default.Send(new ChangePageMessage("main"));
        }

        #endregion Navigation
    }
}