using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace mvvm_light_sample.Model
{
    public class ProgressParameter : INotifyPropertyChanged
    {
        /// <summary>
        /// ダイアログに表示するメッセージ
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Max(完了値)
        /// </summary>
        public int Max { get; set; }
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
        /// <summary>
        /// IsIndeterminate(進捗をループで表示するか、値で表示するか。)
        /// </summary>
        public bool IsIndeterminate { get; set; }
        /// <summary>
        /// 処理のAction
        /// </summary>
        public Action<CancellationTokenSource> ProgressAction { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string name)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }


    }
}
