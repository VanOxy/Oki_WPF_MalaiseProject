using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.Message;
using WPF.UnivercityService;

namespace WPF.ViewModel
{
    public class ProfessorsViewModel : ViewModelBase
    {
        public ProfessorsViewModel()
        {
            ChangeToMainPageCommand = new RelayCommand(ChangeToMainPage);
            GetTeachersFromService();
        }

        private void GetTeachersFromService()
        {
            DynamicCollection = new ObservableCollection<Teacher>();
            TeachersList teachersList;
            using (var service = new UnivercityServiceClient())
            {
                teachersList = service.GetTeachersList();
            }

            foreach (var teacher in teachersList.Teachers)
            {
                DynamicCollection.Add(teacher);
            }
        }

        #region Data

        public ObservableCollection<Teacher> DynamicCollection { get; set; }

        #endregion Data

        #region Navigation

        public ICommand ChangeToMainPageCommand { get; set; }

        private void ChangeToMainPage()
        {
            Messenger.Default.Send(new ChangePageMessage("main"));
        }

        #endregion Navigation
    }
}