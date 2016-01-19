using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight;

namespace mvvm_light_sample.Common
{
    public class ProgressStatusMessage4
    {
        public ViewModelBase VM { get; set; }
        public string Text { get; set; }
        public double ProgressValue1 { get; set; }
        public double ProgressValue2 { get; set; }
        public bool CloseWindow { get; set; }
    }
}
