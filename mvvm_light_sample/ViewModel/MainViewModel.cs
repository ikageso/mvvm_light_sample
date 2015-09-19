using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using mvvm_light_sample.Common;
using System.Diagnostics;
using System.Windows;
using mvvm_light_sample.Common;
using mvvm_light_sample.Model;
using System.Threading;
using System.Threading.Tasks;

namespace mvvm_light_sample.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            MessageBoxButtonCommand = new RelayCommand(MessageBoxButton);
            OpenFileCommand = new RelayCommand(OpenFile);
            SaveFileCommand = new RelayCommand(SaveFile);
            ProgressStartCommand1 = new RelayCommand(ProgressStart1);
            ProgressStartCommand2 = new RelayCommand(ProgressStart2);
            ProgressStartCommand3 = new RelayCommand(ProgressStart3);
        }

        #region プロパティ
        public RelayCommand MessageBoxButtonCommand { get; set; }
        public RelayCommand OpenFileCommand { get; set; }
        public RelayCommand SaveFileCommand { get; set; }
        public RelayCommand ProgressStartCommand1 { get; set; }
        public RelayCommand ProgressStartCommand2 { get; set; }
        public RelayCommand ProgressStartCommand3 { get; set; }
        public RelayCommand ProgressCancelCommand { get; set; }

        private string _OpenFileName;
        /// <summary>
        /// OpenFileName
        /// </summary>
        public string OpenFileName
        {
            get
            {
                return _OpenFileName;
            }
            set
            {
                _OpenFileName = value;
                RaisePropertyChanged("OpenFileName");
            }
        }

        private string _SaveFileName;
        /// <summary>
        /// SaveFileName
        /// </summary>
        public string SaveFileName
        {
            get
            {
                return _SaveFileName;
            }
            set
            {
                _SaveFileName = value;
                RaisePropertyChanged("SaveFileName");
            }
        }
        #endregion

        #region メソッド
        private void MessageBoxButton()
        {
            ShowMessageBox("メッセージ");
        }

        private void OpenFile()
        {
            bool? res = false;
            string filename = string.Empty;

            Messenger.Default.Send<OpenFileMessage>(
                new OpenFileMessage()
                {
                    FilterIndex = 1,
                    Filter = "テキスト ファイル(.txt)|*.txt|HTML File(*.html, *.htm)|*.html;*.htm|All Files (*.*)|*.*",
                    Callback = (result, openFilename) =>
                    {
                        res = result;
                        filename = openFilename;
                    }
                });

            if (res == true)
                OpenFileName = filename;
        }

        private void SaveFile()
        {
            bool? res = false;
            string filename = string.Empty;

            Messenger.Default.Send<SaveFileMessage>(
                new SaveFileMessage()
                {
                    FilterIndex = 1,
                    Filter = "テキスト ファイル(.txt)|*.txt|HTML File(*.html, *.htm)|*.html;*.htm|All Files (*.*)|*.*",
                    Callback = (result, saveFilename) =>
                    {
                        res = result;
                        filename = saveFilename;
                    }
                });

            if (res == true)
                SaveFileName = filename;
        }

        private void ProgressStart1()
        {
            MessageBoxResult res = MessageBoxResult.None;

            Messenger.Default.Send<ProgressMessage>(new ProgressMessage()
            {
                Parameter = ProgressModel.ProgressAction1(),
                Callback = (result) =>
                {
                    res = result;

                    Debug.WriteLine(result.ToString());
                }
            });


            if (res == MessageBoxResult.Cancel)
                ShowMessageBox("キャンセルされました");
            else
                ShowMessageBox("完了しました");
        }

        private void ProgressStart2()
        {
            MessageBoxResult res = MessageBoxResult.None;

            Messenger.Default.Send<ProgressMessage>(new ProgressMessage()
            {
                Parameter = ProgressModel.ProgressAction2(),
                Callback = (result) =>
                {
                    res = result;

                    Debug.WriteLine(result.ToString());
                }
            });


            if (res == MessageBoxResult.Cancel)
                ShowMessageBox("キャンセルされました");
            else
                ShowMessageBox("完了しました");
        }

        private void ProgressStart3()
        {
            var cancelTokenSource = new CancellationTokenSource();
            Task task = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        if (cancelTokenSource.IsCancellationRequested)
                        {
                            Debug.WriteLine("キャンセルされました。");
                            // ウィンドウクローズ
                            Messenger.Default.Send<ProgressStatusMessage>(new ProgressStatusMessage()
                            {
                                Text = null,
                                CloseWindow = true
                            });

                            return;
                        }

                        // 進捗表示
                        Messenger.Default.Send<ProgressStatusMessage>(new ProgressStatusMessage()
                        {
                            ProgressValue1 = (double)(j + 1) * (double)(100 / 100),
                            ProgressValue2 = (double)(i) * (double)(100 / 5),
                        });

                        Thread.Sleep(10);

                    }

                    double parsent = (double)(i + 1) * (double)(100 / 5);
                    // 進捗表示
                    Messenger.Default.Send<ProgressStatusMessage>(new ProgressStatusMessage()
                    {
                        Text = string.Format("バックグラウンド処理中...{0}%", parsent),
                        ProgressValue2 = parsent,
                    });
                }
                Debug.WriteLine("完了しました。");

                // ウィンドウクローズ
                Messenger.Default.Send<ProgressStatusMessage>(new ProgressStatusMessage()
                {
                    CloseWindow = true
                });

            });
        

            // ダイアログ表示
            MessageBoxResult res = MessageBoxResult.None;
            Messenger.Default.Send<Progress2Message>(new Progress2Message()
            {
                Text = "バックグラウンド処理中... ",
                IsIndeterminate1 = false,
                IsIndeterminate2 = false,
                Callback = (result) =>
                {
                    res = result;

                    Debug.WriteLine(result.ToString());
                }
            });

            if (res == MessageBoxResult.Cancel)
            {
                cancelTokenSource.Cancel();
            }

            // Task終了待ち
            bool bRes = task.Wait(3000);
            string str = string.Empty;
           
            if (cancelTokenSource.IsCancellationRequested)
            {
                str = "キャンセルされました。";
            }
            else
            {
                str = "完了しました。";
            }

            if (!bRes)
            {
                str += "\nタスク終了待ちでタイムアウトが発生しました。";
            }

            ShowMessageBox(str);


        }

        private MessageBoxResult ShowMessageBox(string text, string caption="", MessageBoxButton button = System.Windows.MessageBoxButton.OK, MessageBoxImage icon = MessageBoxImage.Information)
        {
            MessageBoxResult res = MessageBoxResult.None;

            Messenger.Default.Send<MessageBoxMessage>(
            new MessageBoxMessage()
            {
                Text = text,
                Caption = caption,
                Button = button,
                Icon = icon,
                Callback = (result) =>
                {
                    Debug.WriteLine(result.ToString());
                    res = (MessageBoxResult)result;
                }
            });

            return res;
        }
        #endregion
    }
}