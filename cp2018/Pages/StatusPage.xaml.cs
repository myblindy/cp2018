using cp2018.Models;
using System;
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

namespace cp2018.Pages
{
    /// <summary>
    /// Interaction logic for StatusPage.xaml
    /// </summary>
    public partial class StatusPage : UserControl, IPageTab, INotifyPropertyChanged
    {
        public StatusPage()
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

            DataContext = this;
        }

        private bool designmode = false;
        public bool DesignMode
        {
            get => designmode;
            set { designmode = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void DesignMode_Executed(object sender, ExecutedRoutedEventArgs e) =>
            DesignMode = (bool)e.Parameter;

        private void DesignMode_CanExecute(object sender, CanExecuteRoutedEventArgs e) =>
            e.CanExecute = true;
    }
}
