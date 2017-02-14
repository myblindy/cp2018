using cp2018.Models;
using cp2018.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace cp2018.ValueConverters
{
    class MonitoredItemStatusToImageConverter : IValueConverter
    {
        private static BitmapImage LoadResource(string name) =>
            new BitmapImage(new Uri("pack://application:,,,/" + Assembly.GetExecutingAssembly().GetName().Name + $";component/Images/{name}.png", UriKind.Absolute));

        private static Dictionary<MonitoredItemStatus, BitmapImage> Images = new Dictionary<MonitoredItemStatus, BitmapImage>
        {
            { MonitoredItemStatus.Active, LoadResource("button-green") },
            { MonitoredItemStatus.Error, LoadResource("button-red") },
            { MonitoredItemStatus.Offline, LoadResource("button-red") },
            { MonitoredItemStatus.Unknown, LoadResource("button-gray") },
            { MonitoredItemStatus.Warning, LoadResource("button-yellow") },
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => Images[(MonitoredItemStatus)value];

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
