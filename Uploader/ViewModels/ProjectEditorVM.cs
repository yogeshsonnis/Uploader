using Uploader.DB;
using Uploader.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows;

namespace Uploader.ViewModels
{
    public class ProjectEditorVM : BaseViewModel
    {       
        private ProjectItem projectItem;
        private ContainerSetting containerSetting;

        public ObservableCollection<ProjectViewItem> ProjectStepList { get;  set; } = new ObservableCollection<ProjectViewItem>();

        private ProjectViewItem selectedStep;
        public ProjectViewItem SelectedStep 
        { 
            get {  return selectedStep; }
            private set 
            { 
                selectedStep= value;
                OnPropertyChanged("SelectedStep");
            }
        }

        public ProjectItem ProjectItem
        {
            get { return projectItem; }
            private set
            {
                projectItem = value;
                OnPropertyChanged("ProjectItem");
            }
        }


        public ProjectEditorVM(ProjectItem projectItem, ContainerSetting setting)
        {
            this.projectItem = projectItem;
            this.containerSetting = setting;

            LoadProject(projectItem);


        }

        private void CloseProject(object x)
        {
            // Todo Close Project
        }

        async private void LoadProject(ProjectItem projectItem)
        {
            ProjectRepo repo = new ProjectRepo(containerSetting);
            var projectInfo = new ProjectInfo(); //await repo.GetProjectAsync(projectItem.Identifier);
           
            //Application.Current.Dispatcher.BeginInvoke((Action)delegate
            //{
            //    GenerateViews(projectInfo);
               
            //});
           
        }

        private void GenerateViews(ProjectInfo projectInfo)
        {
            var projectInfoView = new InfoEditorView();
            var projectInfoVM = new InfoEditorVM(projectInfo);
            projectInfoView.DataContext = projectInfoVM;
            var viewItem = new ProjectViewItem(projectInfoView, projectInfoVM, "Info");
            ProjectStepList.Add(viewItem);

            int stepCount = 0;
            foreach (var step in projectInfo.stepList)
            {
                var stepView = new StepEditorView();
                var stepVM = new StepEditorVM(step);
                stepView.DataContext = stepVM;

                ProjectStepList.Add(new ProjectViewItem(stepView, stepVM, "Step " + (stepCount++ + 1)));
            }
        }
    }

}
