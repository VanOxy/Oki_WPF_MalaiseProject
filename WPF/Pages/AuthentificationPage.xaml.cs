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
            credentials.IsEnabled = false;
            progressRing.IsActive = true;
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
            });
            progressRing.IsActive = false;
            credentials.IsEnabled = true;
        }
    }
}