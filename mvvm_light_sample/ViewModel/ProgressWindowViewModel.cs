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

namespace mvvm_light_sample.ViewModel
{
    public class ProgressWindowViewModel : ViewModelBase
    {
        BackgroundWorker bw;

        public ProgressWindowViewModel()
        {
            // キャンセルボタン押下時のコマンド登録
            CancelCommand = new RelayCommand(() => 
                {
                    if(bw != null)
                        bw.CancelAsync();

                    Result = MessageBoxResult.Cancel;
                    this.CloseWindow = true;
                });

            ContentRenderedCommand = new RelayCommand(() => 
            {
                 DoWork();
 
            });

        }

        /// <summary>
        /// IsVisibleChangedCommand
        /// </summary>
        public RelayCommand ContentRenderedCommand { get; private set; }


        /// <summary>
        /// CancelCommand
        /// </summary>
        public RelayCommand CancelCommand { get; private set; }

        private Action _MyAction;
        /// <summary>
        /// MyAction
        /// </summary>
        public Action MyAction
        {
            get
            {
                return _MyAction;
            }
            set
            {
                _MyAction = value;
                RaisePropertyChanged("MyAction");
            }
        }

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

        /// <summary>
        /// Result
        /// </summary>
        public MessageBoxResult Result { get; set; }


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

        /// <summary>
        /// DoWork
        /// </summary>
        public void DoWork()
        {

            bool isCompleted = false;

            // 重い処理
            new Thread(new ThreadStart(() =>
            {
                if (MyAction != null)
                    MyAction();
                isCompleted = true;
            })).Start();


            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler((sender, e) =>
            {
                BackgroundWorker bwRef = sender as BackgroundWorker;
                int interval = 100;
                while (true)
                {
                    // 重い処理完了待ち
                    if (isCompleted)
                    {
                        break;
                    }

                    Thread.Sleep(interval);

                    if (bwRef.CancellationPending)
                    {
                        e.Cancel = true;
                        Debug.WriteLine("キャンセルされました。");
                        return;
                    }
                }

                // 処理完了時ダイアログを閉じる（WindowViewModelのResultに値を設定する）
                this.Result = MessageBoxResult.OK;
                this.CloseWindow = true;
            });
            bw.RunWorkerAsync();
        }

    }
}
