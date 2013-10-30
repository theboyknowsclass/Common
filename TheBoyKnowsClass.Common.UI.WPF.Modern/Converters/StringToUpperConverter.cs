using System;
using System.Globalization;
using System.Windows.Data;

namespace TheBoyKnowsClass.Common.UI.WPF.Modern.Converters
{
    public class StringToUpperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            return "";
            var text = value as string;
            return text != null ? text.ToUpper() : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
