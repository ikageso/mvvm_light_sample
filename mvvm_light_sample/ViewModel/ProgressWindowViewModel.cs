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
    public class ProgressWindowViewModel : ViewModelBase
    {
        public ProgressWindowViewModel()
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
                        Parameter.Result = MessageBoxResult.Cancel;
                        Parameter.CloseWindow = true;
                    });
                }

                return _CancelCommand;
            }
        }

        /// <summary>
        /// Parameter
        /// </summary>
        public ProgressParameter Parameter { get; set; }

    }
}
