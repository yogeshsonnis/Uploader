using Uploader.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader.ViewModels
{
    internal class ProjectSelectVM: BaseViewModel
    {
        private ContainerSetting selectedContainer;
        public ContainerSetting SelectedContainer
        {
            get { return selectedContainer; }
            set 
            { 
                selectedContainer = value;
                PopulateProjects(selectedContainer);
                OnPropertyChanged("SelectedContainer"); 
            }
        }

        private ProjectItem selectedProject;
        public ProjectItem SelectedProject
        {
            get { return selectedProject; }
            set
            {
                selectedProject = value;
                OnPropertyChanged("SelectedProject");
            }
        }

        public ObservableCollection<ContainerSetting> ContainerList { get; } = new ObservableCollection<ContainerSetting>();

        public ObservableCollection<ProjectItem> ProjectItemList { get; } = new ObservableCollection<ProjectItem>();

        public ProjectSelectVM()
        {
            PopulateContainerCombo();
        }

        private void PopulateProjects(ContainerSetting container)
        {
            if (container == null) return;

            ProjectItemList.Clear();

            ProjectRepo repo = new ProjectRepo(container);
            var projectList = repo.GetProjectItemList();

            foreach (var project in projectList)
                ProjectItemList.Add(project);
        }

        private void PopulateContainerCombo()
        {
            foreach (var item in ContainerSetting.StorageSettingList)
                ContainerList.Add(item);
        }
    }
}
