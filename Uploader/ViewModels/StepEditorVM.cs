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
        }
    }
}
