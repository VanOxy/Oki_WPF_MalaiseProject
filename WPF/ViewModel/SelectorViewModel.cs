using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using WPF.Message;
using WPF.Pages;

namespace WPF.ViewModel
{
    public class SelectorViewModel : ViewModelBase
    {
        private MainPage _mainPage;
        private StudentsPage _studentsPage;
        private ProfessorsPage _professorsPage;
        private CoursPage _coursPage;
        private SectionsPage _sectionsPage;
        private FacultiesPage _facultiesPage;
        private AuthentificationPage _authentificationPage;

        // the page which is binded with MainWindow
        private Page _activePage;

        public Page ActivePage
        {
            get { return _activePage; }
            set
            {
                if (_activePage == value)
                    return;
                _activePage = value;
                RaisePropertyChanged("ActivePage");
            }
        }

        public SelectorViewModel()
        {
            _authentificationPage = new AuthentificationPage();
            ActivePage = _authentificationPage;
            //_mainPage = new MainPage();
            //ActivePage = _mainPage;
            Messenger.Default.Register<ChangePageMessage>(this, ChangePage);
        }

        /// <summary>
        /// Method which will change the active page (binded into MainWindow) by the page asked by user.
        /// The information about the page is transmitted into message (MVVMLight.Messenger class).
        /// </summary>
        /// <param name="message"></param>
        private void ChangePage(ChangePageMessage message)
        {
            switch (message.PageName)
            {
                case "authentification":
                    if (_authentificationPage == null)
                        _authentificationPage = new AuthentificationPage();
                    ActivePage = _authentificationPage;
                    break;

                case "main":
                    if (_mainPage == null)
                        _mainPage = new MainPage();
                    ActivePage = _mainPage;
                    break;

                case "students":
                    if (_studentsPage == null)
                        _studentsPage = new StudentsPage();
                    ActivePage = _studentsPage;
                    break;

                case "professors":
                    if (_professorsPage == null)
                        _professorsPage = new ProfessorsPage();
                    ActivePage = _professorsPage;
                    break;

                case "cours":
                    if (_coursPage == null)
                        _coursPage = new CoursPage();
                    ActivePage = _coursPage;
                    break;

                case "sections":
                    if (_sectionsPage == null)
                        _sectionsPage = new SectionsPage();
                    ActivePage = _sectionsPage;
                    break;

                case "faculties":
                    if (_facultiesPage == null)
                        _facultiesPage = new FacultiesPage();
                    ActivePage = _facultiesPage;
                    break;

                default:
                    break;
            }
        }
    }
}