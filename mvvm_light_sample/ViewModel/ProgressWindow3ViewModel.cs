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
                        Parameter.CancelTokenSource.Cancel();
                    });
                }

                return _CancelCommand;
            }
        }

        /// <summary>
        /// Parameter
        /// </summary>
        public Progress3Parameter Parameter { get; set; }

        private RelayCommand<System.ComponentModel.CancelEventArgs> _WindowClosingCommand;
        /// <summary>
        /// WindowClosingCommand
        /// </summary>
        public RelayCommand<System.ComponentModel.CancelEventArgs> WindowClosingCommand
        {
            get
            {
                if (_WindowClosingCommand == null)
                {
                    _WindowClosingCommand = new RelayCommand<CancelEventArgs>((e) =>
                    {
                        try
                        {
                            if (!Parameter.CancelTokenSource.Token.IsCancellationRequested)
                            {
                                Parameter.CancelTokenSource.Cancel();
                                e.Cancel = true;
                            }
                        }
                        catch { }
                    });
                }

                return _WindowClosingCommand;
            }
        }
    }
}
