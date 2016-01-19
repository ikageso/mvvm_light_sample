using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using mvvm_light_sample.Common;
using System.Diagnostics;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;
using System;
using GalaSoft.MvvmLight.Threading;
using System.Collections.ObjectModel;

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
            ProgressStartCommand4 = new RelayCommand(ProgressStart4);
            ProgressStartCommand5 = new RelayCommand(ProgressStart5);
            ProgressCancelCommand5 = new RelayCommand<object>(ProgressCancel5);
        }

        #region �v���p�e�B
        public RelayCommand MessageBoxButtonCommand { get; set; }
        public RelayCommand OpenFileCommand { get; set; }
        public RelayCommand SaveFileCommand { get; set; }
        public RelayCommand ProgressStartCommand1 { get; set; }
        public RelayCommand ProgressStartCommand2 { get; set; }
        public RelayCommand ProgressStartCommand3 { get; set; }
        public RelayCommand ProgressStartCommand4 { get; set; }
        public RelayCommand ProgressStartCommand5 { get; set; }
        public RelayCommand<object> ProgressCancelCommand5 { get; set; }

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

        #region ���\�b�h
        private void MessageBoxButton()
        {
            ShowMessageBox("���b�Z�[�W");
        }

        private void OpenFile()
        {
            bool? res = false;
            string filename = string.Empty;

            Messenger.Default.Send<OpenFileMessage>(
                new OpenFileMessage()
                {
                    FilterIndex = 1,
                    Filter = "�e�L�X�g �t�@�C��(.txt)|*.txt|HTML File(*.html, *.htm)|*.html;*.htm|All Files (*.*)|*.*",
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
                    Filter = "�e�L�X�g �t�@�C��(.txt)|*.txt|HTML File(*.html, *.htm)|*.html;*.htm|All Files (*.*)|*.*",
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
            var cancelTokenSource = new CancellationTokenSource();

            var parameter = new ProgressParameter()
            {
                IsIndeterminate = false,
                Max = 50,
                Message = "�������ł�"
            };

            var task = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    parameter.Value++;  // �i��++

                    // �L�����Z���������ǂ���
                    if (cancelTokenSource.IsCancellationRequested)
                        break;

                    System.Threading.Thread.Sleep(100);
                    Debug.WriteLine(i.ToString());
                }

                // �_�C�A���O�N���[�Y
                parameter.CloseWindow = true;

            });

            Messenger.Default.Send<ProgressMessage>(new ProgressMessage()
            {
                Parameter = parameter,
            });

            if (parameter.Result == MessageBoxResult.Cancel)
            {
                cancelTokenSource.Cancel();
            }

            // Task�I���҂�
            bool bRes = task.Wait(3000);
            string str = string.Empty;

            if (cancelTokenSource.IsCancellationRequested)
            {
                str = "�L�����Z������܂����B";
            }
            else
            {
                str = "�������܂����B";
            }

            if (!bRes)
            {
                str += "\n�^�X�N�I���҂��Ń^�C���A�E�g���������܂����B";
            }

            ShowMessageBox(str);
        }

        private void ProgressStart2()
        {
            var cancelTokenSource = new CancellationTokenSource();

            var parameter = new ProgressParameter()
            {
                IsIndeterminate = true,
                Message = "�������ł�"
            };

            var task = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    // �L�����Z���������ǂ���
                    if (cancelTokenSource.IsCancellationRequested)
                        break;

                    System.Threading.Thread.Sleep(100);
                    Debug.WriteLine(i.ToString());
                }

                // �_�C�A���O�N���[�Y
                parameter.CloseWindow = true;

            });


            Messenger.Default.Send<ProgressMessage>(new ProgressMessage()
            {
                Parameter = parameter,
            });

            if (parameter.Result == MessageBoxResult.Cancel)
            {
                cancelTokenSource.Cancel();
            }

            // Task�I���҂�
            bool bRes = task.Wait(3000);
            string str = string.Empty;

            if (cancelTokenSource.IsCancellationRequested)
            {
                str = "�L�����Z������܂����B";
            }
            else
            {
                str = "�������܂����B";
            }

            if (!bRes)
            {
                str += "\n�^�X�N�I���҂��Ń^�C���A�E�g���������܂����B";
            }

            ShowMessageBox(str);
        }

        /// <summary>
        /// �Q�i
        /// </summary>
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
                            Debug.WriteLine("�L�����Z������܂����B");
                            // �E�B���h�E�N���[�Y
                            Messenger.Default.Send<ProgressStatusMessage>(new ProgressStatusMessage()
                            {
                                CloseWindow = true
                            });

                            return;
                        }

                        Thread.Sleep(10);// �����̏���

                        // �i���\��
                        Messenger.Default.Send<ProgressStatusMessage>(new ProgressStatusMessage()
                        {
                            ProgressValue1 = (double)(j + 1) * (double)(100 / 100),
                            ProgressValue2 = (double)(i) * (double)(100 / 5),
                        });
                    }

                    double parsent = (double)(i + 1) * (double)(100 / 5);
                    // �i���\��
                    Messenger.Default.Send<ProgressStatusMessage>(new ProgressStatusMessage()
                    {
                        Text = string.Format("�o�b�N�O���E���h������...{0}%", parsent),
                        ProgressValue2 = parsent,
                    });
                }
                Debug.WriteLine("�������܂����B");

                // �E�B���h�E�N���[�Y
                Messenger.Default.Send<ProgressStatusMessage>(new ProgressStatusMessage()
                {
                    CloseWindow = true
                });

            });
        

            // �_�C�A���O�\��
            MessageBoxResult res = MessageBoxResult.None;
            Messenger.Default.Send<Progress2Message>(new Progress2Message()
            {
                Text = "�o�b�N�O���E���h������... ",
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

            // Task�I���҂�
            bool bRes = task.Wait(3000);
            string str = string.Empty;
           
            if (cancelTokenSource.IsCancellationRequested)
            {
                str = "�L�����Z������܂����B";
            }
            else
            {
                str = "�������܂����B";
            }

            if (!bRes)
            {
                str += "\n�^�X�N�I���҂��Ń^�C���A�E�g���������܂����B";
            }

            ShowMessageBox(str);


        }

        private ObservableCollection<ProgressTask> _TaskList = new ObservableCollection<ProgressTask>();
        /// <summary>
        /// TaskList
        /// </summary>
        public ObservableCollection<ProgressTask> TaskList
        {
            get
            {
                return _TaskList;
            }
            set
            {
                _TaskList = value;
                RaisePropertyChanged("TaskList");
            }
        }


        /// <summary>
        /// �Q�i�i�񓯊��j
        /// </summary>
        private void ProgressStart5()
        {
            var progressTask = new ProgressTask()
            {
                CancelToken = new CancellationTokenSource(),
            };

            ViewModelBase vm = null;

            Task task = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        if (progressTask.CancelToken.IsCancellationRequested)
                        {
                            Debug.WriteLine("�L�����Z������܂����B");
                            return;
                        }

                        Thread.Sleep(10);// �����̏���

                        // �i���\��
                        Messenger.Default.Send<ProgressStatusMessage4>(new ProgressStatusMessage4()
                        {
                            VM = vm,
                            ProgressValue1 = (double)(j + 1) * (double)(100 / 100),
                            ProgressValue2 = (double)(i) * (double)(100 / 5),
                        });
                    }

                    double parsent = (double)(i + 1) * (double)(100 / 5);
                    // �i���\��
                    Messenger.Default.Send<ProgressStatusMessage4>(new ProgressStatusMessage4()
                    {
                        VM = vm,
                        Text = string.Format("�o�b�N�O���E���h������...{0}%", parsent),
                        ProgressValue2 = parsent,
                    });
                }
                Debug.WriteLine("�������܂����B");

            }, progressTask.CancelToken.Token).ContinueWith((t) =>
            {

                string str = string.Empty;

                if (progressTask.CancelToken.IsCancellationRequested)
                {
                    str = "�L�����Z������܂����B";
                }
                else
                {
                    str = "�������܂����B";
                }

                // �������b�Z�[�W�\��
                DispatcherHelper.CheckBeginInvokeOnUI(
                () =>
                {
                    Messenger.Default.Send<MessageBox2Message>(new MessageBox2Message()
                    {
                        SenderVM = vm,
                        Text = str,
                        Caption = "",
                        Button = System.Windows.MessageBoxButton.OK,
                        Icon = MessageBoxImage.Information,
                        Callback = (result) =>
                        {
                            Debug.WriteLine(result.ToString());

                            progressTask.CancelToken.Dispose();
                            progressTask.CancelToken = null;

                            // �������E�B���h�E�N���[�Y
                            Messenger.Default.Send<ProgressStatusMessage4>(new ProgressStatusMessage4()
                            {
                                VM = vm,
                                CloseWindow = true
                            });

                            TaskList.Remove(progressTask);
                        }
                    });
                });


            });

            progressTask.Name = task.Id.ToString();

            TaskList.Add(progressTask);
            
            // �������E�B���h�E�\��
            Messenger.Default.Send<Progress4Message>(new Progress4Message()
            {
                CancelTokenSource = progressTask.CancelToken,
                IsAsync = true,
                Text = "�o�b�N�O���E���h������... ",
                IsIndeterminate1 = false,
                IsIndeterminate2 = false,
                Callback = (viewModel) =>
                {
                    vm = viewModel as ViewModelBase;
                },
            });

        }

        /// <summary>
        /// �Q�i�i�񓯊��j�̃L�����Z��
        /// </summary>
        private void ProgressCancel5(object param)
        {
            var task = param as ProgressTask;
            if (task != null)
            {
                task.CancelToken.Cancel();
            }
        }


        /// <summary>
        /// �񓯊��E�B���h�E
        /// </summary>
        private void ProgressStart4()
        {

            var cancelTokenSource = new CancellationTokenSource();
            ProgressWindow3ViewModel vm = null;

            var param = new Progress3Parameter()
            {
                CancelTokenSource = cancelTokenSource,
                Text = "�o�b�N�O���E���h������... ",
                IsIndeterminate1 = false,
                IsIndeterminate2 = false,
            };

            // �������E�B���h�E�\��
            Messenger.Default.Send<Progress3Message>(new Progress3Message()
            {
                Parameter = param,
                Callback = (viewModel) => vm = viewModel as ProgressWindow3ViewModel
            });

            Task.Factory.StartNew(() =>
            {
                try
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            if (cancelTokenSource.IsCancellationRequested)
                            {
                                Debug.WriteLine("�L�����Z������܂����B");
                                return;
                            }

                            Thread.Sleep(10);// �����̏���

                            // �i���\��
                            param.ProgressValue1 = (double)(j + 1) * (double)(100 / 100);
                            param.ProgressValue2 = (double)(i) * (double)(100 / 5);
                        }

                        // �i���\��
                        double parsent = (double)(i + 1) * (double)(100 / 5);
                        param.Text = string.Format("�o�b�N�O���E���h������...{0}%", parsent);
                        param.ProgressValue2 = parsent;
                    }
                    Debug.WriteLine("�������܂����B");
                }
                catch { }


            }, cancelTokenSource.Token).ContinueWith((t) =>
            {
                string str = string.Empty;

                if (cancelTokenSource.IsCancellationRequested)
                {
                    str = "�L�����Z������܂����B";
                }
                else
                {
                    str = "�������܂����B";
                }

                // �������b�Z�[�W�\��
                DispatcherHelper.CheckBeginInvokeOnUI(
                () =>
                {
                    Messenger.Default.Send<MessageBox2Message>(new MessageBox2Message()
                    {
                        SenderVM = vm,
                        Text = str,
                        Caption = "",
                        Button = System.Windows.MessageBoxButton.OK,
                        Icon = MessageBoxImage.Information,
                        Callback = (result) =>
                        {
                            Debug.WriteLine(result.ToString());

                            cancelTokenSource.Dispose();
                            cancelTokenSource = null;

                            // �������E�B���h�E�N���[�Y
                            param.CloseWindow = true;

                        }
                    });
                });


            });


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