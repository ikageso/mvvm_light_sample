using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace mvvm_light_sample.Common
{
    public class SaveFileMessage
    {
        public int FilterIndex { get; set; }
        public string Filter { get; set; }
        public Action<bool?,string> Callback { get; set; }
    }
}
