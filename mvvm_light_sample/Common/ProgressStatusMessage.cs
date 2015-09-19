using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace mvvm_light_sample.Common
{
    public class ProgressStatusMessage
    {
        public string Text { get; set; }
        public double ProgressValue1 { get; set; }
        public double ProgressValue2 { get; set; }
        public bool CloseWindow { get; set; }
    }
}
