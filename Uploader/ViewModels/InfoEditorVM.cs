using Uploader.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader.ViewModels
{
    internal class InfoEditorVM : BaseViewModel
    {
        private ProjectInfo projectInfo;

        public InfoEditorVM(ProjectInfo projectInfo)
        {
            this.projectInfo = projectInfo;
            MapProjectInfo(projectInfo);
        }

        private void MapProjectInfo(ProjectInfo projectInfo)
        {
            this.name = projectInfo.name;
            this.category = projectInfo.category;
            this.domain = projectInfo.domain;
            this.extension1 = projectInfo.extension1;
            this.extension1AudioFile = projectInfo.extension1AudioFile;
            this.intro = projectInfo.intro;
            this.introAudioFile = projectInfo.introAudioFile;
            this.active = projectInfo.active;
            this.summary = projectInfo.summary;
            this.summaryAudioFile = projectInfo.summaryAudioFile;
            this.materialIdList = projectInfo.materialIdList;
            this.stepList = projectInfo.stepList;

        }

        string _name;
        public string name
        {
            get { return _name; }
            set
            {
                _name = value; OnPropertyChanged("name");
            }
        }


        string _category { get; set; }
        string _domain { get; set; }
        string _intro { get; set; }
        string _introAudioFile { get; set; }
        string _introImageFile { get; set; }
        string _summary { get; set; }
        string _summaryAudioFile { get; set; }
        string _extension1 { get; set; }
        string _extension1AudioFile { get; set; }

        public string summaryAudioFile
        {
            get { return _summaryAudioFile; }
            set
            {
                _summaryAudioFile = value; OnPropertyChanged("summaryAudioFile");
            }
        }

        public string category
        {
            get { return _category; }
            set
            {
                _category = value; OnPropertyChanged("category");
            }
        }

        public string domain
        {
            get { return _domain; }
            set
            {
                _domain = value; OnPropertyChanged("domain");
            }
        }
        public string intro
        {
            get { return _intro; }
            set
            {
                _intro = value; OnPropertyChanged("intro");
            }
        }

        public string introAudioFile
        {
            get { return _introAudioFile; }
            set
            {
                _introAudioFile = value; OnPropertyChanged("introAudioFile");
            }
        }
        public string summary
        {
            get { return _summary; }
            set
            {
                _summary = value; OnPropertyChanged("summary");
            }
        }

        public string extension1
        {
            get { return _extension1; }
            set
            {
                _extension1 = value; OnPropertyChanged("extension1");
            }
        }

        public string extension1AudioFile
        {
            get { return _extension1AudioFile; }
            set
            {
                _extension1AudioFile = value; OnPropertyChanged("extension1AudioFile");
            }
        }

        bool _active;
        public bool active
        {
            get { return _active; }
            set
            {
                _active = value; OnPropertyChanged("active");
            }
        }

        public List<int> materialIdList { get; set; }
        public List<ProjectStep> stepList { get; set; }
    }
}
