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
        CancellationTokenSource _CancellationTokenSource = new CancellationTokenSource();

        public ProgressWindowViewModel()
        {
            // キャンセルボタン押下時のコマンド登録
            CancelCommand = new RelayCommand(() => 
                {
                    if (_CancellationTokenSource != null)
                        _CancellationTokenSource.Cancel();
                });

            ContentRenderedCommand = new RelayCommand(() =>
            {

                var token = _CancellationTokenSource.Token;

                // 重い処理
                Task.Factory.StartNew(() =>
                {
                    if (MyAction != null)
                        MyAction(_CancellationTokenSource);


                }, token).ContinueWith(t =>
                {
                    if (_CancellationTokenSource.IsCancellationRequested)
                    {
                        Debug.WriteLine("キャンセルされました。");
                        Result = MessageBoxResult.Cancel;

                    }
                    else
                    {
                        Debug.WriteLine("完了しました。");
                        this.Result = MessageBoxResult.OK;
                    }
                    this.CloseWindow = true;
                });

            });

        }

        public ProgressParameter Parameter { get; set; }

        /// <summary>
        /// IsVisibleChangedCommand
        /// </summary>
        public RelayCommand ContentRenderedCommand { get; private set; }

        /// <summary>
        /// CancelCommand
        /// </summary>
        public RelayCommand CancelCommand { get; private set; }

        /// <summary>
        /// MyAction
        /// </summary>
        public Action<CancellationTokenSource> MyAction
        {
            get
            {
                return Parameter.ProgressAction;
            }
            set
            {
                Parameter.ProgressAction = value;
            }
        }

        /// <summary>
        /// Result
        /// </summary>
        public MessageBoxResult Result { get; set; }

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
    }
}
