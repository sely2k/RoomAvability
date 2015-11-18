namespace RoomAvability.Tools.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public sealed class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var item = (DateTimeOffset)value;
            if (item != null)
            {
                return item.ToString("yyyy MMM dd hh:mm tt"); 
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException("ConvertBack DateTimeConverter");
        }
    }
}
