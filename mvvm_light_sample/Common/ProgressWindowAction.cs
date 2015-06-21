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
    // MessageBox を表示するアクション
    public class ProgressWindowAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            var msg = parameter as ProgressMessage;
            if (msg != null)
            {
                var vm = new ProgressWindowViewModel() { Parameter = msg.Parameter };
                var window = new ProgressWindow() { DataContext = vm };

                window.ShowDialog();

                msg.Callback(vm.Result);
            }
        }
    }
}
