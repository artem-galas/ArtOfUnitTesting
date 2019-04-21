using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) {
                throw new ArgumentException("filename has to be provided");
            }
            if (!fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            return true;
        }
    }
}
