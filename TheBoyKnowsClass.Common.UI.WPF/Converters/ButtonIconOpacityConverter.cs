using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace TheBoyKnowsClass.Common.UI.WPF.Converters
{
    public class ButtonIconOpacityConverter : MarkupExtension, IValueConverter
    {
        public ButtonIconOpacityConverter()
        {
            Opacity = 0.3;
        }

        public bool TransparentIfTrue { get; set; }
        public double Opacity { get; set; }

        private static readonly ButtonIconOpacityConverter Instance = new ButtonIconOpacityConverter();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && ((bool)value))
            {
                return 1;
            }
            return Opacity;
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
