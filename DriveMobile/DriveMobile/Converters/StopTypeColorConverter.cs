using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DriveMobile.Converters
{
    class StopTypeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int stopTypeId = (int)value;

            Dictionary<int, Color> stopTypeColor = new Dictionary<int, Color>();

            stopTypeColor.Add(1, Color.Purple); // 1
            stopTypeColor.Add(2, Color.Teal); // 2
            stopTypeColor.Add(3, Color.OrangeRed); // 3
            stopTypeColor.Add(4, Color.IndianRed); // 4
            stopTypeColor.Add(5, Color.Brown); // 5
            stopTypeColor.Add(6, Color.DarkSlateBlue); // 6
            stopTypeColor.Add(7, Color.Cyan); // 7
            stopTypeColor.Add(8, Color.Orange); // 8
            stopTypeColor.Add(9, Color.Pink); // 9
            stopTypeColor.Add(10, Color.DodgerBlue); // 10
            stopTypeColor.Add(11, Color.PeachPuff); // 11
            stopTypeColor.Add(12, Color.Indigo); // 12
            stopTypeColor.Add(14, Color.Black); // 14, thanks Brett! 13 is unlucky anyway. 

            return stopTypeColor[stopTypeId];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
