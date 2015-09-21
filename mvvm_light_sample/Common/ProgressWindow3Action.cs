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
    public class ProgressWindow3Action : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            var msg = parameter as Progress3Message;
            if (msg != null)
            {
                var vm = new ProgressWindow3ViewModel() { Parameter = msg.Parameter };
                var window = new ProgressWindow3() { DataContext = vm };

                window.Show();

                msg.Callback(vm);
            }
        }
    }
}
