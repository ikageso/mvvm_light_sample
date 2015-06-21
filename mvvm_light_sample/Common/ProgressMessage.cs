using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mvvm_light_sample.Common
{
    public class ProgressMessage
    {
        public string Message { get; set; }
        public Action ProgressAction { get; set; }
        public Action<object> Callback { get; set; }
    }
}
