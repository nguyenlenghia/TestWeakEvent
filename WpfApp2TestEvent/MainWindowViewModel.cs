using System;
using System.Windows;
using System.Windows.Input;

namespace WpfApp2TestEvent
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private string _labelName;
        private string _textName;

        public string LabelName
        {
            get { return _labelName; }
            set
            {
                _labelName = value;
                RaisePropertyChange();
            }
        }

        public string TextName
        {
            get => _textName;
            set
            {
                _textName = value;
                RaisePropertyChange();
            }
        }

        public ICommand DeleteCommand { get; private set; }

        public MainWindowViewModel()
        {
            LabelName = "default";
            DeleteCommand = new RelayCommand(o => Delete(), o => !string.IsNullOrEmpty(TextName));

            WeakEventManager<DataModel, EventArgs>.AddHandler(DataModel.Instance, "DataChange", NotifyChange);
        }

        public void Delete()
        {
            TextName = "";

            var window = new SecondWindow();
            window.Show();
        }

        public void NotifyChange(object sender, EventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("bgn MainWindowViewModel.NotifyChange");

            TextName = DataModel.Instance.Current?.ToString("u");

            System.Diagnostics.Debug.WriteLine("end MainWindowViewModel.NotifyChange");
        }
    }
}