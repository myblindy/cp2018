using cp2018.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cp2018.Infrastructure
{
    /// <summary>
    /// Interaction logic for MonitorItemsControl.xaml
    /// </summary>
    public partial class MonitorItemsControl : UserControl
    {
        private class MonitoredItemWrapper : INotifyPropertyChanged
        {
            private double x;
            public double X
            {
                get { return x; }
                set
                {
                    if (x != value)
                    {
                        x = value;
                        NotifyPropertyChanged();
                    }
                }
            }

            private double y;
            public double Y
            {
                get { return y; }
                set
                {
                    if (y != value)
                    {
                        y = value;
                        NotifyPropertyChanged();
                    }
                }
            }

            private MonitoredItem @object;
            public MonitoredItem Object
            {
                get { return @object; }
                set
                {
                    @object = value;
                    NotifyPropertyChanged();
                }
            }

            public MonitoredItemWrapper(double x, double y, MonitoredItem obj) { X = x; Y = y; Object = obj; }

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged([CallerMemberName] string propertyName = null) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MonitorItemsControl()
        {
            InitializeComponent();
        }

        IEnumerable realItemsSource;
        public IEnumerable ItemsSource
        {
            get { return realItemsSource; }
            set
            {
                Items.ItemsSource = (realItemsSource = value).Cast<MonitoredItem>().Select(o => new MonitoredItemWrapper(0, 0, o)).ToArray();
                UpdateItemsLayout();
            }
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            UpdateItemsLayout();
        }

        void UpdateItemsLayout()
        {
            if (ActualWidth == 0)
                return;

            var margin = (Thickness)Application.Current.Resources["MonitoredItemsControlMargin"];
            var tilew = 1 + margin.Left + (double)Application.Current.Resources["MonitoredItemsControlTileWidth"] + margin.Right + 1;
            var tileh = 1 + margin.Top + (double)Application.Current.Resources["MonitoredItemsControlTileHeight"] + margin.Bottom + 1;

            int x = 0, y = 0;
            var maxw = (int)Math.Floor(ActualWidth / tilew);

            var bitmap = new List<BitArray> { new BitArray(maxw) };

            Func<int, int, MonitoredItem, bool> fits = (bmpx, bmpy, item) =>
              {
                  while (bmpy + item.Height >= bitmap.Count) bitmap.Add(new BitArray(maxw));
                  return maxw >= bmpx + item.Width &&
                    bitmap.Skip(bmpy).Take(item.Height).All(r => r.Cast<bool>().Skip(bmpx).Take(item.Width).All(w => !w));
              };

            foreach (MonitoredItemWrapper witem in Items.ItemsSource)
            {
                // does this fit?
                while (x >= maxw || !fits(x, y, witem.Object))
                    if (++x >= maxw)
                    {
                        x = 0; ++y;
                    }

                // position this guy
                witem.X = x * tilew; witem.Y = y * tileh;

                // write the bitmap
                for (int bmpy = y; bmpy < y + witem.Object.Height; ++bmpy)
                {
                    while (bmpy >= bitmap.Count) bitmap.Add(new BitArray(maxw));
                    for (int bmpx = x; bmpx < x + witem.Object.Width; ++bmpx)
                        bitmap[bmpy].Set(bmpx, true);
                }
            }
        }
    }
}
