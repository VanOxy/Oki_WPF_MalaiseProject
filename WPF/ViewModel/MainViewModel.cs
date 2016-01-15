using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Message;

namespace WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            SwitchToStudentsPageCommand = new RelayCommand(SwitchToStudentsPage);
            SwitchToProfessorsPageCommand = new RelayCommand(SwitchToProfessorsPage);
            SwitchToCoursesPageCommand = new RelayCommand(SwitchToCoursesPage);
            SwitchToSectionsPageCommand = new RelayCommand(SwitchToSectionsPage);
            SwitchToFacultiesPageCommand = new RelayCommand(SwitchToFacultiesPage);
        }

        #region Navigation

        public ICommand SwitchToStudentsPageCommand { get; private set; }
        public ICommand SwitchToProfessorsPageCommand { get; private set; }
        public ICommand SwitchToCoursesPageCommand { get; private set; }
        public ICommand SwitchToSectionsPageCommand { get; private set; }
        public ICommand SwitchToFacultiesPageCommand { get; private set; }

        private void SwitchToStudentsPage()
        {
            Messenger.Default.Send(new ChangePageMessage("students"));
        }

        private void SwitchToProfessorsPage()
        {
            Messenger.Default.Send(new ChangePageMessage("professors"));
        }

        private void SwitchToCoursesPage()
        {
            Messenger.Default.Send(new ChangePageMessage("cours"));
        }

        private void SwitchToSectionsPage()
        {
            Messenger.Default.Send(new ChangePageMessage("sections"));
        }

        private void SwitchToFacultiesPage()
        {
            Messenger.Default.Send(new ChangePageMessage("faculties"));
        }

        #endregion Navigation
    }
}