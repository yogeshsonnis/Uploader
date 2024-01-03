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
        }
    }
}
