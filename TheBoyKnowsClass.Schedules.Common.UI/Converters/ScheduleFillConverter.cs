using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;

namespace TheBoyKnowsClass.Schedules.Common.UI.Converters
{
    class ScheduleFillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Color.Green : Color.LightGreen;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Color)value == Color.Green;
        }
    }
}
