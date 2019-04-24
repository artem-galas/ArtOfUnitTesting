using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        public IExtensionManager extentionManager;
        public LogAnalyzer(IExtensionManager _extentionManager) {
            extentionManager = _extentionManager;
        }

        public bool WasLastFileNameValid { get; set; }

        public bool IsValidLogFileName(string fileName)
        {
            // uses the extract class
            return extentionManager.IsValid(fileName);
        }
    }
}
