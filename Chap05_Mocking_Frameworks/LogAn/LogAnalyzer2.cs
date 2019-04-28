using System;

namespace Chap05.LogAn
{
    public class LogAnalyzer2
    {
        private ILogger _logger;
        private IWebService _webService;

        public int MinNameLength { get; set; }

        public LogAnalyzer2(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public void Analyze(string filename)
        {
            if (filename.Length < MinNameLength)
            {
                try
                {
                    _logger.LogError($"Filename too short: {filename}");
                }
                catch (Exception e)
                {
                    _webService.Write($"Error From Logger: {e}");
                }
            }
        }
    }
}