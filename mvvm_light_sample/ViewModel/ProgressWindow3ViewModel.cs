using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Threading.Tasks;
using mvvm_light_sample.Common;

namespace mvvm_light_sample.ViewModel
{
    public class ProgressWindow3ViewModel : ViewModelBase
    {
        public ProgressWindow3ViewModel()
        {
        }

        private RelayCommand _CancelCommand = null;
        /// <summary>
        /// CancelCommand
        /// </summary>
        public RelayCommand CancelCommand
        {
            get
            {
                if (_CancelCommand == null)
                {
                    _CancelCommand = new RelayCommand(() =>
                    {
                        this.CancelTokenSource.Cancel();
                    });
                }

                return _CancelCommand;
            }
        }

        public CancellationTokenSource CancelTokenSource { get; set; }

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

        private string _Text;
        /// <summary>
        /// Text
        /// </summary>
        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
                RaisePropertyChanged("Text");
            }
        }

        private bool _IsIndeterminate1;
        /// <summary>
        /// IsIndeterminate1
        /// </summary>
        public bool IsIndeterminate1
        {
            get
            {
                return _IsIndeterminate1;
            }
            set
            {
                _IsIndeterminate1 = value;
                RaisePropertyChanged("IsIndeterminate1");
            }
        }

        private bool _IsIndeterminate2;
        /// <summary>
        /// IsIndeterminate2
        /// </summary>
        public bool IsIndeterminate2
        {
            get
            {
                return _IsIndeterminate2;
            }
            set
            {
                _IsIndeterminate2 = value;
                RaisePropertyChanged("IsIndeterminate2");
            }
        }
    }
}
