using System;
using System.Windows.Data;
using System.Windows;
using System.Globalization;
using System.Windows.Markup;

namespace TheBoyKnowsClass.Common.UI.WPF.Converters
{
    public class VisibilityConverter : MarkupExtension, IValueConverter, IMultiValueConverter
    {
        public VisibilityConverter()
        {
            HiddenVisibility = Visibility.Collapsed;
        }

        private static readonly VisibilityConverter Instance = new VisibilityConverter();

        public Visibility HiddenVisibility { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToBoolean(parameter) == System.Convert.ToBoolean(value) ? Visibility.Visible : HiddenVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible == System.Convert.ToBoolean(parameter);
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool totalValue = true;

            foreach (var value in values)
            {
                if (value is bool)
                {
                    totalValue = System.Convert.ToBoolean(value) && totalValue;
                }
            }

            return System.Convert.ToBoolean(parameter) == System.Convert.ToBoolean(totalValue) ? Visibility.Visible : HiddenVisibility;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
