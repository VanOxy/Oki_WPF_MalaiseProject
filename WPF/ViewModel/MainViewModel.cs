using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Message;
using WPF.Messages;

namespace WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Messenger.Default.Send(new ProgressRingMessage(true));
            RegisterCommands();
            GetGeneralData();
        }

        private void RegisterCommands()
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

        #region General Data

        private string _studentsNumber = "";
        private string _teachersNumber = "";
        private string _coursesNumber = "";
        private string _facultiesNumber = "";
        private string _sectionsNumber = "";

        public string StudentsNumber
        {
            get { return _studentsNumber; }
            set { _studentsNumber = value; RaisePropertyChanged("StudentsNumber"); }
        }

        public string TeachersNumber
        {
            get { return _teachersNumber; }
            set { _teachersNumber = value; RaisePropertyChanged("TeachersNumber"); }
        }

        public string CoursesNumber
        {
            get { return _coursesNumber; }
            set { _coursesNumber = value; RaisePropertyChanged("CoursesNumber"); }
        }

        public string FacultiesNumber
        {
            get { return _facultiesNumber; }
            set { _facultiesNumber = value; RaisePropertyChanged("FacultiesNumber"); }
        }

        public string SectionsNumber
        {
            get { return _sectionsNumber; }
            set { _sectionsNumber = value; RaisePropertyChanged("SectionsNumber"); }
        }

        private void GetGeneralData()
        {
            using (var service = new UnivercityService.UnivercityServiceClient())
            {
                StudentsNumber = service.GetStudentsNumber().ToString();
                TeachersNumber = service.GetTeachersNumber().ToString();
                CoursesNumber = service.GetCoursesNumber().ToString();
                FacultiesNumber = service.GetFacultiesNumber().ToString();
                SectionsNumber = service.GetSectionsNumber().ToString();
            }
            Messenger.Default.Send(new ProgressRingMessage(false));
        }

        #endregion General Data
    }
}