using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace mvvm_light_sample.Common
{
    public class ProgressTask : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public CancellationTokenSource CancelToken { get; set; }

        private double _ProgressValue1;
        /// <summary>
        /// ProgressValue1
        /// </summary>
        public double ProgressValue1
        {
            get
            {
                return _ProgressValue1;
            }
            set
            {
                _ProgressValue1 = value;
                RaisePropertyChanged("ProgressValue1");
            }
        }

        private double _ProgressValue2;
        /// <summary>
        /// ProgressValue2
        /// </summary>
        public double ProgressValue2
        {
            get
            {
                return _ProgressValue2;
            }
            set
            {
                _ProgressValue2 = value;
                RaisePropertyChanged("ProgressValue2");
            }
        }

        private string _Result;
        /// <summary>
        /// Result
        /// </summary>
        public string Result
        {
            get
            {
                return _Result;
            }
            set
            {
                _Result = value;
                RaisePropertyChanged("Result");
            }
        }


        #region INotifyPropertyChanged メンバー

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string name)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
