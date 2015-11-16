﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using WPF.Message;

namespace WPF.ViewModel
{
    public class SecondViewModel : ViewModelBase
    {
        public ICommand ChangeToMainPageCommand { get; set; }

        public SecondViewModel()
        {
            ChangeToMainPageCommand = new RelayCommand(ChangeToMainPage);
        }

        private void ChangeToMainPage()
        {
            Messenger.Default.Send(new ChangePageMessage("main"));
        }
    }
}