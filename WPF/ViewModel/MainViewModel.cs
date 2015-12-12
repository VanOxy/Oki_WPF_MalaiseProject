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
            AskWebServiceCommand = new RelayCommand(AskWebService);
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

        public ICommand AskWebServiceCommand { get; private set; }

        private string _serviceAnswer;

        public string ServiceAnswer
        {
            get { return _serviceAnswer; }
            set
            {
                if (value == _serviceAnswer)
                    return;
                _serviceAnswer = value;
                RaisePropertyChanged("ServiceAnswer");
            }
        }

        private string _serviceAsk;

        public string ServiceAsk
        {
            get { return _serviceAsk; }
            set
            {
                if (_serviceAsk == value)
                    return;
                _serviceAsk = value;
                RaisePropertyChanged("ServiceAsk");
            }
        }

        private async void AskWebService()
        {
            using (var service = new WebService.Service1Client())
            {
                ServiceAnswer = await service.GetDataAsync(ServiceAsk);
            }
        }
    }
}