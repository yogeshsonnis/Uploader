using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader.DB
{
    public class ProjectInfo
    {
        public string name { get; set; }
        public bool active { get; set; }
        public string category { get; set; }
        public string domain { get; set; }
        public string intro { get; set; }
        public string introAudioFile { get; set; }
        public string introImageFile { get; set; }
        public string summary { get; set; }
        public string summaryAudioFile { get; set; }
        public string extension1 { get; set; }
        public string extension1AudioFile { get; set; }
        public List<int> materialIdList { get; set; }
        public List<ProjectStep> stepList { get; set; }
    }
}
