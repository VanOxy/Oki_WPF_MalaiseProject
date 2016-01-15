﻿using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Message;

namespace WPF.Pages
{
    public partial class AuthentificationPage : Page
    {
        private bool _authentificationOk = false;

        public AuthentificationPage()
        {
            InitializeComponent();
        }

        private void ChangeToMainPage()
        {
            Messenger.Default.Send(new ChangePageMessage("main"));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = emailTxt.Text;
            string password = passwordTxt.Password;
            string hashedPassword = Utlities.MD5_Hasher.CreateMD5(password);

            errorMessage.Content = "";
            credentials.IsEnabled = false;
            progressRing.IsActive = true;
            bool _authentificationOk = false;

            await Task.Run(() =>
            {
                using (var service = new UnivercityService.UnivercityServiceClient())
                {
                    _authentificationOk = service.TryLogin(email, hashedPassword);
                }
            });

            if (_authentificationOk)
            {
                Messenger.Default.Send(new ChangePageMessage("main"));
            }
            else
            {
                progressRing.IsActive = false;
                credentials.IsEnabled = true;
                errorMessage.Content = "Wrong credentials";
            }
        }
    }
}