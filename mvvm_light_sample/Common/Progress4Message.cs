using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Windows;
using mvvm_light_sample.ViewModel;

namespace mvvm_light_sample.Common
{
    public class Progress4Message
    {
        public CancellationTokenSource CancelTokenSource { get; set; }
        public bool IsAsync { get; set; }
        public string Text { get; set; }
        public bool IsIndeterminate1 { get; set; }
        public bool IsIndeterminate2 { get; set; }
        public Action<object> Callback { get; set; }
    }
}
