using System.IO;

namespace Extensibility
{
    public class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }
        public void LogError(string message)
        {
            Log("ERROR", message); ;            
        }

        public void LogInfo(string message)
        {
            Log("OK", message);
        }

        private void Log(string status, string message)
        {
            using (var streamWriter = new StreamWriter(_path, true))
            {
                streamWriter.WriteLine($"{status}: {message}");
            };
        }
    }
}
