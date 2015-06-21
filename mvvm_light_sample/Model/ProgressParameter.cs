using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace mvvm_light_sample.Model
{
    public class ProgressParameter : INotifyPropertyChanged
    {
        public string Message { get; set; }
        public int Max { get; set; }
        private int _Value;
        /// <summary>
        /// Value
        /// </summary>
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                RaisePropertyChanged("Value");
            }
        }

        public bool IsIndeterminate { get; set; }
        public Action<CancellationTokenSource> ProgressAction { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string name)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }


    }
}
