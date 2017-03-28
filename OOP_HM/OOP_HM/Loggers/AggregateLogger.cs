using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HM.Loggers
{
    public class AggregateLogger : ILogger
    {
        private List<ILogger> _loggers;

        public AggregateLogger()
        {
            _loggers = new List<ILogger>();
        }

        public void RegisterLoggers(params ILogger[] loggers)
        {
            _loggers.AddRange(loggers);
        }

        public void Log(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Log(message);
            }
        }
    }
}
