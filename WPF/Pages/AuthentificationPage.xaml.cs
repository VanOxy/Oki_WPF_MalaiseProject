using GalaSoft.MvvmLight.Messaging;
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
            errorMessage.Content = "";
            credentials.IsEnabled = false;
            progressRingAuth.IsActive = true;
            bool _authentificationOk = false;

            string email = emailTxt.Text;
            string password = passwordTxt.Password;
            string hashedPassword = Utlities.MD5_Hasher.CreateMD5(password);

            using (var service = new UnivercityService.UnivercityServiceClient())
            {
                _authentificationOk = await service.TryLoginAsync(email, hashedPassword);
            }

            if (_authentificationOk)
            {
                progressRingAuth.IsActive = false;
                Messenger.Default.Send(new ChangePageMessage("main"));
            }
            else
            {
                progressRingAuth.IsActive = false;
                credentials.IsEnabled = true;
                errorMessage.Content = "Wrong credentials";
            }
        }
    }
}