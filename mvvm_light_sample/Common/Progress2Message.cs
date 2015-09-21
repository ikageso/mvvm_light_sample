using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Windows;

namespace mvvm_light_sample.Common
{
    public class Progress2Message
    {
        public string Text { get; set; }
        public bool IsIndeterminate1 { get; set; }
        public bool IsIndeterminate2 { get; set; }
        public Action<MessageBoxResult> Callback { get; set; }
    }
}
