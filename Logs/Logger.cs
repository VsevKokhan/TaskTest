namespace Logs
{
    public class Logger
    {
        private readonly string _logFilePath;

        public Logger(string logFilePath)
        {
            _logFilePath = logFilePath;

            if (!File.Exists(_logFilePath))
            {
                using (File.Create(_logFilePath))
                {
                }
            }
        }

        public void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(_logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        public void LogError(string errorMessage)
        {
            Log($"ERROR: {errorMessage}");
        }
    }

}
