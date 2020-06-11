using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CircuitSimulator.Logs
{
    [ExcludeFromCodeCoverage]
    public class Log
    {
        public string Message { get; set; }
        public Brush TextColor { get; set; }

        public Log(string message) : this(message, Brushes.Black) { }

        public Log(string message, Brush textColor)
        {
            Message = message;
            TextColor = textColor;
        }
    }
}
