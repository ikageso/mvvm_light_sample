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
                var window = new ProgressWindow3() { DataContext = msg.vm };

                window.Show();
            }
        }
    }
}
