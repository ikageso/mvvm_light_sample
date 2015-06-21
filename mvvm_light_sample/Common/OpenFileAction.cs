using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;
using Microsoft.Win32;

namespace mvvm_light_sample.Common
{
    // OpenFileDialog を表示するアクション
    public class OpenFileAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            // OpenFileMessage を渡されたら
            // OpenFileDialog を表示する
            var msg = parameter as OpenFileMessage;
            string filename = string.Empty;

            if (msg != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.FilterIndex = msg.FilterIndex;
                openFileDialog.Filter = msg.Filter;
                bool? result = openFileDialog.ShowDialog();
                if (result == true)
                {
                    filename = openFileDialog.FileName;
                }

                msg.Callback(result, filename);
            }
        }
    }
}
