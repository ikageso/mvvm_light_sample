using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;
using mvvm_light_sample.View;
using mvvm_light_sample.ViewModel;
using Microsoft.Practices.ServiceLocation;

namespace mvvm_light_sample.Common
{
    // ProgressWindow2 を表示するアクション
    public class ProgressWindow2Action : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            var msg = parameter as Progress2Message;
            if (msg != null)
            {
                ProgressWindow2ViewModel vm = new ProgressWindow2ViewModel()
                    {
                        Text = msg.Text,
                        IsIndeterminate1 = msg.IsIndeterminate1,
                        IsIndeterminate2 = msg.IsIndeterminate2
                    };
                var window = new ProgressWindow2() { DataContext = vm };

                window.ShowDialog();

                msg.Callback(vm.Result);
            }
        }
    }
}
