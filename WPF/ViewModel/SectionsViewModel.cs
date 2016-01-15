using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.Message;
using WPF.UnivercityService;

namespace WPF.ViewModel
{
    public class SectionsViewModel : ViewModelBase
    {
        public SectionsViewModel()
        {
            ChangeToMainPageCommand = new RelayCommand(ChangeToMainPage);

            GetSectionsFromService();
        }

        private void GetSectionsFromService()
        {
            DynamicCollection = new ObservableCollection<Section>();
            SectionsList sectionsList;
            using (var service = new UnivercityServiceClient())
            {
                sectionsList = service.GetSectionsList();
            }

            foreach (var sec in sectionsList.Sections)
            {
                DynamicCollection.Add(sec);
            }
        }

        #region Data

        public ObservableCollection<Section> DynamicCollection { get; set; }

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