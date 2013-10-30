using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace TheBoyKnowsClass.Common.UI.WPF.Converters
{
    public class CursorConverter : MarkupExtension, IValueConverter
    {
        private static readonly CursorConverter Instance = new CursorConverter();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && ((bool)value))
            {
                return "Wait";
            }
            return "Arrow";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }
    }
}
