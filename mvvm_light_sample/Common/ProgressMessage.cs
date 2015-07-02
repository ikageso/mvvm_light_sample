using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using mvvm_light_sample.Model;
using System.Windows;

namespace mvvm_light_sample.Common
{
    public class ProgressMessage
    {
        public ProgressParameter Parameter { get; set; }
        public Action<MessageBoxResult> Callback { get; set; }

    }
}
