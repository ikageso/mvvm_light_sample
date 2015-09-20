using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;

namespace mvvm_light_sample.Common
{
    // MessageBox を表示するアクション
    public class MessageBoxAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            // MessageBoxMessage を渡されたら
            // MessageBox を表示する
            var msg = parameter as MessageBoxMessage;
            if (msg != null)
            {
                var result = MessageBox.Show(
                    //(Window)AssociatedObject,
                    msg.Text,
                    msg.Caption,
                    msg.Button,
                    msg.Icon,
                    MessageBoxResult.None,
                    MessageBoxOptions.DefaultDesktopOnly
                    );
                msg.Callback(result);
            }
        }
    }
}
