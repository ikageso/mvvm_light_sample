using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;
using Microsoft.Win32;

namespace mvvm_light_sample.Common
{
    // SaveFileDialog を表示するアクション
    public class SaveFileAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            // SaveFileMessage を渡されたら
            // SaveFileDialog を表示する
            var msg = parameter as SaveFileMessage;
            string filename = string.Empty;

            if (msg != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FilterIndex = msg.FilterIndex;
                saveFileDialog.Filter = msg.Filter;
                bool? result = saveFileDialog.ShowDialog();
                if (result == true)
                {
                    filename = saveFileDialog.FileName;
                }

                msg.Callback(result, filename);
            }
        }
    }
}
