using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace mvvm_light_sample.Common
{
    public class ProgressTask
    {
        public string Name { get; set; }
        public CancellationTokenSource CancelToken { get; set; }
    }
}
