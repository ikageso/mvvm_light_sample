using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using mvvm_light_sample.Common;
using System.Diagnostics;
using System.Windows;
using mvvm_light_sample.Common;
using mvvm_light_sample.Model;

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
        }

        #region プロパティ
        public RelayCommand MessageBoxButtonCommand { get; set; }
        public RelayCommand OpenFileCommand { get; set; }
        public RelayCommand SaveFileCommand { get; set; }
        public RelayCommand ProgressStartCommand1 { get; set; }
        public RelayCommand ProgressStartCommand2 { get; set; }
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