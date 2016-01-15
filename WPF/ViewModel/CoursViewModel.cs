using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.Message;
using WPF.UnivercityService;

namespace WPF.ViewModel
{
    public class CoursViewModel : ViewModelBase
    {
        public CoursViewModel()
        {
            ChangeToMainPageCommand = new RelayCommand(ChangeToMainPage);

            GetTeachersFromService();
        }

        private void GetTeachersFromService()
        {
            DynamicCollection = new ObservableCollection<Course>();
            CoursesList coursesList;
            using (var service = new UnivercityServiceClient())
            {
                coursesList = service.GetCoursesList();
            }

            foreach (var course in coursesList.Courses)
            {
                DynamicCollection.Add(course);
            }
        }

        #region Data

        public ObservableCollection<Course> DynamicCollection { get; set; }

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