using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace mvvm_light_sample.Common
{
    public class MessageBoxMessage
    {
        public string Caption { get; set; }
        public string Text { get; set; }
        public Action<object> Callback { get; set; }
        public MessageBoxButton Button { get; set; }
        public MessageBoxImage Icon { get; set; }
    }
}
