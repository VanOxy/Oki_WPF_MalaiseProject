using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace WPF.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Register ViewModels
            SimpleIoc.Default.Register<SelectorViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<StudentsViewModel>();
            SimpleIoc.Default.Register<ProfessorsViewModel>();
            SimpleIoc.Default.Register<CoursViewModel>();
            SimpleIoc.Default.Register<SectionsViewModel>();
            SimpleIoc.Default.Register<FacultiesViewModel>();
        }

        #region Declaring ViewModels

        public SelectorViewModel Selector
        {
            get { return ServiceLocator.Current.GetInstance<SelectorViewModel>(); }
        }

        public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public StudentsViewModel Students
        {
            get { return ServiceLocator.Current.GetInstance<StudentsViewModel>(); }
        }

        public ProfessorsViewModel Professors
        {
            get { return ServiceLocator.Current.GetInstance<ProfessorsViewModel>(); }
        }

        public CoursViewModel Cours
        {
            get { return ServiceLocator.Current.GetInstance<CoursViewModel>(); }
        }

        public SectionsViewModel Sections
        {
            get { return ServiceLocator.Current.GetInstance<SectionsViewModel>(); }
        }

        public FacultiesViewModel Faculties
        {
            get { return ServiceLocator.Current.GetInstance<FacultiesViewModel>(); }
        }

        #endregion Declaring ViewModels

        public static void Cleanup()
        {
        }
    }
}