using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace mvvm_light_sample.ViewModel
{
    public class MessageWindowViewModel : ViewModelBase
    {
        public MessageWindowViewModel()
        {
            Result = MessageBoxResult.None;

            // ボタン押下時のコマンド登録
            ButtonCommand = new RelayCommand<string>((e) =>
            {
                switch (e)
                {
                    case "ok":
                        Result = MessageBoxResult.OK;
                        break;

                    case "cancel":
                        Result = MessageBoxResult.Cancel;
                        break;

                    case "yes":
                        Result = MessageBoxResult.Yes;
                        break;

                    case "no":
                        Result = MessageBoxResult.No;
                        break;
                    
                    default:
                        Result = MessageBoxResult.None;
                        break;
                }

                this.CloseWindow = true;
            });

        }
        #region コマンド

        /// <summary>
        /// CancelCommand
        /// </summary>
        public RelayCommand<string> ButtonCommand { get; private set; }

        /// <summary>
        /// WindowClosingCommand
        /// </summary>
        public RelayCommand<System.ComponentModel.CancelEventArgs> WindowClosingCommand { get; private set; }

        /// <summary>
        /// Result
        /// </summary>
        public MessageBoxResult Result { get; set; }
        #endregion

        #region プロパティ

        private bool _CloseWindow;
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

        private string _Caption;
        /// <summary>
        /// Caption
        /// </summary>
        public string Caption
        {
            get
            {
                return _Caption;
            }
            set
            {
                _Caption = value;
                RaisePropertyChanged("Caption");
            }
        }

        private string _MessageBoxText;
        /// <summary>
        /// MessageBoxText
        /// </summary>
        public string MessageBoxText
        {
            get
            {
                return _MessageBoxText;
            }
            set
            {
                _MessageBoxText = value;
                RaisePropertyChanged("MessageBoxText");
            }
        }

        private MessageBoxButton _Button;
        /// <summary>
        /// Button
        /// </summary>
        public MessageBoxButton Button
        {
            get
            {
                return _Button;
            }
            set
            {
                _Button = value;
                RaisePropertyChanged("Button");
            }
        }

        private MessageBoxImage _Icon;
        /// <summary>
        /// Icon
        /// </summary>
        public MessageBoxImage Icon
        {
            get
            {
                return _Icon;
            }
            set
            {
                _Icon = value;
                RaisePropertyChanged("Icon");
            }
        }
        #endregion
    }
}
