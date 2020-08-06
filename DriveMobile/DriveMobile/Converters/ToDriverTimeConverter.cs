using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DriveMobile.Converters
{
    class ToDriverTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
       
            DateTime dateTime = (DateTime)value;
            string timeZone = Preferences.Get("Timezone", string.Empty);
            TimeZoneInfo tzInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, tzInfo);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
