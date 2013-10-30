using System;
using System.Windows.Data;
using TheBoyKnowsClass.Common.Enumerations;
using TheBoyKnowsClass.SystemServices.Common.Enumerations;

namespace TheBoyKnowsClass.SystemServices.Common.UI.Converters
{
    public class SystemServiceStatusConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var serviceStatus = (SystemServiceStatus)value;
            return serviceStatus.GetEnumDescription();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
