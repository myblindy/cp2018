using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace cp2018.Models
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PageTabEntry> TabsList { get; } = new ObservableCollection<PageTabEntry>();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    class PageTabEntry : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get => name;
            set { name = value; NotifyPropertyChanged(); }
        }

        private IPageTab content;
        public IPageTab Content
        {
            get => content;
            set { content = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    interface IPageTab
    {
    }
}
