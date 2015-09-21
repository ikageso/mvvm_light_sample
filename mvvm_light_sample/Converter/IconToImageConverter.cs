using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Drawing;

namespace mvvm_light_sample.Converter
{
    class IconToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            MessageBoxImage iconType = (MessageBoxImage)value;

            Icon icon = null;
            BitmapSource bms = null;

            switch (iconType)
            {
                case MessageBoxImage.Error:
                    icon = SystemIcons.Error;
                    break;

                case MessageBoxImage.Information:
                    icon = SystemIcons.Information;
                    break;

                case MessageBoxImage.Question:
                    icon = SystemIcons.Question;
                    break;

                case MessageBoxImage.Warning:
                    icon = SystemIcons.Warning;
                    break;
            }


            if(icon != null)
            {
                bms =
                    Imaging.CreateBitmapSourceFromHIcon(
                        icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

                icon.Dispose();
            }

            return bms;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
