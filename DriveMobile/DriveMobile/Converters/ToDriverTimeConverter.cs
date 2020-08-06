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
            Dictionary<string, string> timeZoneConvert = new Dictionary<string, string>();

            timeZoneConvert.Add("US/Eastern", "US Eastern Standard Time");
            timeZoneConvert.Add("US/Central", "Central Standard Time");
            DateTime dateTime = (DateTime)value;
            string timeZone = Preferences.Get("Timezone", string.Empty);
            string convertedTz = timeZoneConvert[timeZone];
            TimeZoneInfo tzInfo = TimeZoneInfo.FindSystemTimeZoneById(convertedTz);

            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, tzInfo);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
