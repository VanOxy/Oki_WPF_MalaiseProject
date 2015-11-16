using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Input;
using WPF.Message;

namespace WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            MyString = "Push the Button !";
            IncrementCounterCommand = new RelayCommand(IncrementCounter);
            ChangeToSecondPageCommand = new RelayCommand(ChangeToSecondPage);
            AskWebServiceCommand = new RelayCommand(AskWebService);
        }

        public ICommand IncrementCounterCommand { get; private set; }
        public ICommand ChangeToSecondPageCommand { get; private set; }

        public ICommand AskWebServiceCommand { get; private set; }

        private int counter = 0;

        private string _myString;

        public string MyString
        {
            get
            {
                return _myString;
            }
            set
            {
                if (value == _myString)
                    return;
                _myString = value;
                RaisePropertyChanged("MyString");
            }
        }

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

        private void IncrementCounter()
        {
            counter++;
            MyString = counter.ToString();
        }

        private void ChangeToSecondPage()
        {
            Messenger.Default.Send(new ChangePageMessage("second"));
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