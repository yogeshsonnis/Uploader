using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Uploader.ViewModels
{
    public class ProjectViewItem
    {
        public ProjectViewItem(UserControl userControl, object dataContext, string displayName)
        {
            UserControl = userControl;
            DataContext = dataContext;
            Name = displayName;
        }

        public UserControl UserControl { get;  set; }
        public string Name { get; set; }
        public Object DataContext { get;  set; }
    }
}
