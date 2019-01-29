using System;
using System.Collections.Generic;

namespace WpfApp2TestEvent
{
    internal class SecondWindowViewModel : BaseViewModel
    {
        private string _textName;

        public string TextName
        {
            get => _textName;
            set
            {
                _textName = value;
                RaisePropertyChange();
            }
        }

        public SecondWindowViewModel()
        {
            //WeakEventManager<DataModel, EventArgs>.AddHandler(DataModel.Instance, nameof(DataModel.Instance.DataChange), NotifyChange);
            EventManagerService<DataModel, EventArgs>.AddHandler(DataModel.Instance, o => nameof(o.DataChange), NotifyChange);
            //DataModel.Instance.DataChange += NotifyChange;
        }

        public void NotifyChange(object sender, EventArgs args)
        {
            TextName = DataModel.Instance.Current?.ToString("u");
        }
    }
}