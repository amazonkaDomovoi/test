using System.Text;
using System.IO;

namespace OOP_HM.Loggers
{
    public class FileLogger : ILogger
    {
        string _path;
        public FileLogger(string path)
        {
            _path = path;
        }

        public void Log(string message)
        {
            using (var streamWriter = new StreamWriter(_path, true, Encoding.UTF8, 255))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}
