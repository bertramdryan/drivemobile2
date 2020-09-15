using DriveMobile.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace DriveMobile.Converters
{
    class TrailerInfoVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StopGroup stopGroup = (StopGroup)value;

            if (stopGroup != null)
            {
                if (stopGroup.DepartsWithTrailer || stopGroup.ArrivesWithTrailer)
                    return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
