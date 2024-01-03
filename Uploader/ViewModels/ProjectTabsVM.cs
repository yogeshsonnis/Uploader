using Uploader.DB;
using Uploader.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Uploader.ViewModels
{
    internal class ProjectTabsVM: BaseViewModel
    {
        public ObservableCollection<ProjectEditorVM> OpenProjects { get; set; } = new ObservableCollection<ProjectEditorVM>();
        public ProjectEditorVM selectedProject;
        public ProjectEditorVM SelectedProject
        {
            get { return selectedProject; }
            set
            {
                selectedProject = value;
                OnPropertyChanged("SelectedProject");
            }
        }

        public RelayCommand CloseProject { get; set; }

        public ProjectTabsVM()
        {
            CloseProject = new RelayCommand(s => OnCloseProject(s));
        }

        private void OnCloseProject(object s)
        {
            throw new NotImplementedException(); // Todo
        }

        public void SaveCurrentProject()
        {
            throw new NotImplementedException(); // Todo
        }

        public void OpenProject(ProjectItem projectItem, ContainerSetting settings)
        {
            var vm = new ProjectEditorVM(projectItem, settings);
            OpenProjects.Add(vm);
        }
    }
}
