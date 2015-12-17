using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
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
using WPF.Messages;

namespace WPF.Pages
{
    public partial class StudentsPage : Page
    {
        public StudentsPage()
        {
            InitializeComponent();
            Messenger.Default.Register<ProgressRingMessage>(this, ModifyProgressRingState);
        }

        private void ModifyProgressRingState(ProgressRingMessage state)
        {
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                if (state.Active)
                    ProgressRing.IsActive = true;
                else
                    ProgressRing.IsActive = false;
            }));
        }
    }
}