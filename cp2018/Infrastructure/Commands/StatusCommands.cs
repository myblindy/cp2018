using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace cp2018.Infrastructure.Commands
{
    public static class StatusCommands
    {
        public static readonly RoutedUICommand DesignMode = new RoutedUICommand("Design Mode", "DesignMode", typeof(StatusCommands));
    }
}
