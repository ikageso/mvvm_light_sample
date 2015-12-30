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
    public class ProgressWindow4Action : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            var msg = parameter as Progress4Message;
            if (msg != null)
            {
                var vm = new ProgressWindow4ViewModel()
                {
                    CancelTokenSource = msg.CancelTokenSource,
                    Text = msg.Text,
                    IsIndeterminate1 = msg.IsIndeterminate1,
                    IsIndeterminate2 = msg.IsIndeterminate2,
                };

                var window = new ProgressWindow4() { DataContext = vm };

                if (msg.Callback != null)
                    msg.Callback(vm);

                if (msg.IsAsync)
                    window.Show();
                else
                    window.ShowDialog();
            }
        }
    }
}
