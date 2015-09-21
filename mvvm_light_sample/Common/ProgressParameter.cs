using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using GalaSoft.MvvmLight;
using System.Windows;

namespace mvvm_light_sample.Common
{
    public class ProgressParameter : INotifyPropertyChanged
    {
        public ProgressParameter()
        {
            Result = MessageBoxResult.None;
        }

        /// <summary>
        /// Result
        /// </summary>
        public MessageBoxResult Result { get; set; }

        private string _Message;
        /// <summary>
        /// Message
        /// </summary>
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
                RaisePropertyChanged("Message");
            }
        }

        private int _Max;
        /// <summary>
        /// Max
        /// </summary>
        public int Max
        {
            get
            {
                return _Max;
            }
            set
            {
                _Max = value;
                RaisePropertyChanged("Max");
            }
        }


        private int _Value;
        /// <summary>
        /// Value(進捗値)
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

        private bool _IsIndeterminate;
        /// <summary>
        /// IsIndeterminate
        /// </summary>
        public bool IsIndeterminate
        {
            get
            {
                return _IsIndeterminate;
            }
            set
            {
                _IsIndeterminate = value;
                RaisePropertyChanged("IsIndeterminate");
            }
        }

        private bool _CloseWindow;
        /// <summary>
        /// CloseWindow
        /// </summary>
        public bool CloseWindow
        {
            get
            {
                return _CloseWindow;
            }
            set
            {
                _CloseWindow = value;
                RaisePropertyChanged("CloseWindow");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string name)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }


    }
}
