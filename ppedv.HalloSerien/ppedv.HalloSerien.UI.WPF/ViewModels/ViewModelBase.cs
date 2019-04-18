using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ppedv.HalloSerien.UI.WPF.ViewModels
{
    abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        protected void IChanged([CallerMemberName]string callerMemberName = "")
        {
            OnPropertyChanged(callerMemberName);
        }
    }
}
