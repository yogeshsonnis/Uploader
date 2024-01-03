using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Uploader.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName] string prop = "")
        {
            if (oldValue == null && newValue == null)
                return false;
            if (oldValue != null && oldValue.Equals(newValue))
                return false;
            oldValue = newValue;
            OnPropertyChanged(prop);
            return true;
        }
    }

}
