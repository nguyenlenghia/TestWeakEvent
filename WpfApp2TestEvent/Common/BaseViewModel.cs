using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp2TestEvent
{
    internal class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChange([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        public void Dispose()
        {
            
        }
    }
}