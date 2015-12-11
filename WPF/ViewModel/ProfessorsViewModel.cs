﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using WPF.Message;

namespace WPF.ViewModel
{
    public class ProfessorsViewModel : ViewModelBase
    {
        public ProfessorsViewModel()
        {
            ChangeToMainPageCommand = new RelayCommand(ChangeToMainPage);
        }

        #region Navigation

        public ICommand ChangeToMainPageCommand { get; set; }

        private void ChangeToMainPage()
        {
            Messenger.Default.Send(new ChangePageMessage("main"));
        }

        #endregion Navigation
    }
}