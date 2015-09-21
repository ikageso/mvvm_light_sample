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
    public class Progress3Message
    {
        public Progress3Parameter Parameter { get; set; }
        public Action<object> Callback { get; set; }
    }
}
