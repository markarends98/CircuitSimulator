using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CircuitSimulator.Logs
{
    public class Logger
    {
        private static Logger instance = null;

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        public ObservableCollection<Log> Logs { get; }

        public Logger()
        {
            Logs = new ObservableCollection<Log>();
        }

        public void Log(string message)
        {
            Logs.Add(new Log(message));
        } 

        public void Log(string message, Brush textColor)
        {
            Logs.Add(new Log(message, textColor));
        }

        public void LogError(string message)
        {
            Logs.Add(new Log("Error: " + message, Brushes.Red));
        }

        public void LogSuccess(string message)
        {
            Logs.Add(new Log(message, Brushes.Green));
        }

        public void ClearLogs()
        {
            Logs.Clear();
        }
    }
}
