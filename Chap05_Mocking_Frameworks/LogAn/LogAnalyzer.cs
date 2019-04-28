using System;

namespace Chap05.LogAn
{
    public class LogAnalyzer
    {
        private ILogger _logger;
        public int MinNameLength { get; set; }
        
        public LogAnalyzer(ILogger logger)
        {
            _logger = logger;
        }
        public void Analyze(string filename)
        {
            if (filename.Length<MinNameLength)
            {
                _logger.LogError($"Filename too short: {filename}");
            }
        }
    }
}
