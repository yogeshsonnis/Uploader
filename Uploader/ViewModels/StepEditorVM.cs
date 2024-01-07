using Uploader.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader.ViewModels
{
    internal class StepEditorVM : BaseViewModel
    {
        private ProjectStep step;

        public StepEditorVM(ProjectStep step)
        {
            this.step = step;
            ConvertTpProjectStep(step);
        }

        private void ConvertTpProjectStep(ProjectStep step)
        {
            this.description = step.description;
            this.audioFile = step.audioFile;
            this.imageFile=step.imageFile;
            this.videoFile=step.videoFile;
        }

         string _description;
         string _audioFile;
         string _imageFile;
         string _videoFile;

        public string audioFile
        {
            get { return _audioFile; }
            set
            {
                _audioFile = value; OnPropertyChanged("introAudioFile");
            }
        }
        public string description
        {
            get { return _description; }
            set
            {
                _description = value; OnPropertyChanged("description");
            }
        }

        public string imageFile
        {
            get { return _imageFile; }
            set
            {
                _imageFile = value; OnPropertyChanged("extension1");
            }
        }

        public string videoFile
        {
            get { return _videoFile; }
            set
            {
                _videoFile = value; OnPropertyChanged("extension1AudioFile");
            }
        }
    }
}
