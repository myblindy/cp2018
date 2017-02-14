using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cp2018.Models
{
    enum MonitoredItemStatus
    {
        Active,
        Warning,
        Error,
        Offline,
        Unknown
    }

    class MonitoredItem : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyPropertyChanged();
            }
        }

        private MonitoredItemStatus status = MonitoredItemStatus.Unknown;
        public MonitoredItemStatus Status
        {
            get { return status; }
            set
            {
                status = value;
                NotifyPropertyChanged();
            }
        }

        private int height = 1, width = 1;
        public int Height
        {
            get { return height; }
            set
            {
                height = value;
                NotifyPropertyChanged();
            }
        }
        public int Width
        {
            get { return width; }
            set
            {
                width = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
