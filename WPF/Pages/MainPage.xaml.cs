using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
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
using WPF.Messages;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Messenger.Default.Register<ProgressRingMessage>(this, ChangeRingState);
        }

        private void ChangeRingState(ProgressRingMessage obj)
        {
            if (obj.Active == true)
                progressRing.IsActive = true;
            else
                progressRing.IsActive = false;
        }
    }
}