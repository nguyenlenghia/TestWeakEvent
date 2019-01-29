using System;
using System.Threading;

namespace WpfApp2TestEvent
{
    public class DataModel {

        public static DataModel _instance;

        public static DataModel Instance { get { return _instance ?? (_instance = new DataModel()); } }

        public DateTime? Current { get; set; }

        public event EventHandler DataChange;

        public void Log()
        {
            while (true)
            {
                Thread.Sleep(1000);
                this.Current = DateTime.Now;

                DataChange?.Invoke(this, new EventArgs());
            }
        }
    }
}
