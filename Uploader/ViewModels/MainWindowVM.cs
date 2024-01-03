using Uploader.DB;
using Uploader.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Uploader.ViewModels
{
    internal class MainWindowVM: BaseViewModel
    {
        private UserControl mainViewControl;
        public UserControl MainViewControl
        {
            get { return mainViewControl; }
            set { mainViewControl = value; OnPropertyChanged("MainViewControl"); }
        }


        public ProjectTabsVM OpenProjectTabsVM { get; private set; } = new ProjectTabsVM();

        public RelayCommand OpenProject { get; set; }

        public MainWindowVM()
        {
            OpenProject = new RelayCommand(s => OnOpenProject(s));
        }

        private void OnOpenProject(object s)
        {
            var selectView = new ProjectSelectView();
            var selectViewModel = new ProjectSelectVM();

            selectView.DataContext = selectViewModel;
            bool? result = selectView.ShowDialog();

            if (selectViewModel.SelectedProject != null && result == true)
                OpenProjectTabsVM.OpenProject(selectViewModel.SelectedProject, selectViewModel.SelectedContainer);
        }
    }
}
