using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.Message;
using WPF.UnivercityService;

namespace WPF.ViewModel
{
    public class FacultiesViewModel : ViewModelBase
    {
        public FacultiesViewModel()
        {
            ChangeToMainPageCommand = new RelayCommand(ChangeToMainPage);

            GetTeachersFromService();
        }

        private void GetTeachersFromService()
        {
            DynamicCollection = new ObservableCollection<Faculty>();
            FacultiesList facultiesList;
            using (var service = new UnivercityServiceClient())
            {
                facultiesList = service.GetFacultiesList();
            }

            foreach (var faculty in facultiesList.Faculties)
            {
                DynamicCollection.Add(faculty);
            }
        }

        #region Data

        public ObservableCollection<Faculty> DynamicCollection { get; set; }

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