using cp2018.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace cp2018.ValueConverters
{
    class MonitoredItemWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (MonitoredItem)value;
            return item.Width * (double)Application.Current.Resources["MonitoredItemsControlTileWidth"]
                + (item.Width - 1) * (2 + ((Thickness)Application.Current.Resources["MonitoredItemsControlMargin"]).Left + ((Thickness)Application.Current.Resources["MonitoredItemsControlMargin"]).Right)
                + 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class MonitoredItemHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (MonitoredItem)value;
            return item.Height * (double)Application.Current.Resources["MonitoredItemsControlTileHeight"]
                + (item.Height - 1) * (2 + ((Thickness)Application.Current.Resources["MonitoredItemsControlMargin"]).Top + ((Thickness)Application.Current.Resources["MonitoredItemsControlMargin"]).Bottom)
                + 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
