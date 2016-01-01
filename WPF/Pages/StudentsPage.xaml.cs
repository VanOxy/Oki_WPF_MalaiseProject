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
using WPF.Model;

namespace WPF.Pages
{
    public partial class StudentsPage : Page
    {
        public StudentsPage()
        {
            InitializeComponent();
            Messenger.Default.Register<ProgressRingMessage>(this, ModifyProgressRingState);
            Messenger.Default.Register<ModifyStudentMessage>(this, SendInfoToStudentVM);
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

        /// <summary>
        /// This method recover info from each UI element in page and send its info's to
        /// StudentViewModel via MVVMLight Messaging system. Here via StudentStateMessage.
        /// </summary>
        /// <param name="obj"></param>
        private void SendInfoToStudentVM(ModifyStudentMessage obj)
        {
            int id = obj.StudentId;
            string name = ModifiedName.Text;
            string surname = ModifiedSurname.Text;
            int age = Int16.Parse(ModifiedAge.Text);
            SexEnum sex = (SexEnum)Enum.Parse(typeof(SexEnum), ModifiedSex.Text);
            DateTime? enrollementTime = ModifiedEntryDate.SelectedDate;
            int currentClass = Int16.Parse(ModifiedStudiesYear.Text);

            Messenger.Default.Send(new StudentStateMessage(id, name, surname, age,
                sex, enrollementTime, currentClass));
        }
    }
}