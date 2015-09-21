using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;
using mvvm_light_sample.ViewModel;
using mvvm_light_sample.View;

namespace mvvm_light_sample.Common
{
    // MessageBox を表示するアクション
    public class MessageBox2Action : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            // MessageBoxMessage を渡されたら
            // MessageBox を表示する
            var msg = parameter as MessageBox2Message;
            if (msg != null)
            {
                    var vm = new MessageWindowViewModel()
                    {
                        Caption = msg.Caption,
                        MessageBoxText = msg.Text,
                        Button = msg.Button,
                        Icon = msg.Icon
                    };

                    var window = new MessageWindow() { DataContext = vm };
                    window.Closed += new EventHandler((s, e) => msg.Callback(vm.Result));

                    window.Show();
                   
            }
        }
    }
}
