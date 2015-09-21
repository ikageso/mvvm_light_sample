using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace mvvm_light_sample.Converter
{
    class ButtonToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            MessageBoxButton btn = (MessageBoxButton)value;
            string para = (string)parameter;

            if (parameter.Equals("ok") && btn == MessageBoxButton.OK)
                return Visibility.Visible;

            if (parameter.Equals("ok") && btn == MessageBoxButton.OKCancel)
                return Visibility.Visible;

            if (parameter.Equals("cancel") && btn == MessageBoxButton.OKCancel)
                return Visibility.Visible;

            if (parameter.Equals("cancel") && btn == MessageBoxButton.YesNoCancel)
                return Visibility.Visible;

            if (parameter.Equals("yes") && btn == MessageBoxButton.YesNo)
                return Visibility.Visible;

            if (parameter.Equals("yes") && btn == MessageBoxButton.YesNoCancel)
                return Visibility.Visible;

            if (parameter.Equals("no") && btn == MessageBoxButton.YesNo)
                return Visibility.Visible;

            if (parameter.Equals("no") && btn == MessageBoxButton.YesNoCancel)
                return Visibility.Visible;
  
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
