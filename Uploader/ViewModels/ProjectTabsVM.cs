using Uploader.DB;
using Uploader.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Uploader.ViewModels
{
    public class ProjectTabsVM: BaseViewModel
    {

        private ObservableCollection<TabData> openProjects;
        public ObservableCollection<TabData> OpenProjects
        {
            get { return openProjects; }
            set
            {
                openProjects = value;
                OnPropertyChanged("OpenProjects");
            }
        }

        private TabData selectedTab;
        public TabData SelectedTab
        {
            get { return selectedTab; }
            set
            {
                selectedTab = value;
                OnPropertyChanged("SelectedTab");
            }
        }
        public RelayCommand CloseProject { get; set; }

        public ProjectTabsVM()
        {
            CloseProject = new RelayCommand(s => OnCloseProject(s));
            OpenProjects= new ObservableCollection<TabData>();
        }

        private void OnCloseProject(object s)
        {
            OpenProjects.Remove(s as TabData);
        }

        public void SaveCurrentProject()
        {
            throw new NotImplementedException(); // Todo
        }

        public void OpenProject(ProjectItem projectItem, ContainerSetting settings)
        {
            var vm = new TabData(projectItem, settings);
            SelectedTab = vm;
            OpenProjects.Add(vm);
        }
    }

    public class TabData : BaseViewModel 
    {
        string tabHeader;
        public string TabHeader
        {
            get { return tabHeader; }
            set
            {
                tabHeader = value; OnPropertyChanged("TabHeader");
            }
        }

        private ProjectEditorVM selectedProject;
        public ProjectEditorVM SelectedProject
        {
            get { return selectedProject; }
            set
            {
                selectedProject = value;
                OnPropertyChanged("SelectedProject");
            }
        }

        public TabData(ProjectItem projectItem, ContainerSetting settings) 
        {
            SelectedProject= new ProjectEditorVM(projectItem, settings);
            this.TabHeader = projectItem.Name;
        }
    }
}
