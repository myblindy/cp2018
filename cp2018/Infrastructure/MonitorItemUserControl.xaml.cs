using cp2018.Adorners;
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

namespace cp2018.Infrastructure
{
    /// <summary>
    /// Interaction logic for MonitorItemUserControl.xaml
    /// </summary>
    public partial class MonitorItemUserControl : UserControl
    {
        private MonitorItemsControl monitorItemsControl;
        private MonitorItemsControl MonitorItemsControl
        {
            get
            {
                if (monitorItemsControl != null)
                    return monitorItemsControl;

                return monitorItemsControl = this.FindParent<MonitorItemsControl>();
            }
        }

        public MonitorItemUserControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty DesignModeProperty = DependencyProperty.Register(
            "DesignMode", typeof(bool), typeof(MonitorItemUserControl), new PropertyMetadata(false, OnDesignModeChanged));
        public bool DesignMode { get => (bool)GetValue(DesignModeProperty); set => SetValue(DesignModeProperty, value); }

        private static void OnDesignModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // no selection if not in design mode
            d.SetValue(SelectedProperty, false);
        }

        public static readonly DependencyProperty SelectedProperty = DependencyProperty.Register(
            "Selected", typeof(bool), typeof(MonitorItemUserControl), new PropertyMetadata(false, OnSelectedChanged));
        public bool Selected { get => (bool)GetValue(SelectedProperty); set => SetValue(SelectedProperty, value); }

        private static void OnSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // allow only one item to be selected
            if ((bool)e.NewValue)
            {
                var _this = (MonitorItemUserControl)d;

                // deselect the previously selected item if any
                if (_this.MonitorItemsControl.SelectedItem != null)
                    _this.MonitorItemsControl.SelectedItem.Selected = false;

                // and set ourselves as the selected item
                _this.MonitorItemsControl.SelectedItem = _this;
            }
        }

        private void Item_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DesignMode)
                Selected = true;
        }
    }
}
