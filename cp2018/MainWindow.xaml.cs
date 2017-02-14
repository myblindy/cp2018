using cp2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace cp2018
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var rng = new Random();
            var items = Enumerable.Range(0, 40)
                .Select(i => new MonitoredItem
                {
                    Name = "Item" + i,
                    Description = "Random element " + i,
                    Status = (MonitoredItemStatus)rng.Next(5),
                    Width = rng.Next(1, 3),
                    Height = rng.Next(1, 3)
                })
                .ToArray();

            Items.ItemsSource = items;
        }
    }
}
