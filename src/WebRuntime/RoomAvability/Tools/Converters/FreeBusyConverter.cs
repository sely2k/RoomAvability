namespace RoomAvability.Tools.Converters
{
    using Models;
    using helper;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public sealed class FreeBusyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var lst = (List<RoomAvabilityModel>)value;
            return RoomAvabilityHelper.GetFreeBusy(lst);

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException("ConvertBack FreeBusyConverter");
        }
    }
}
