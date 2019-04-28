using System;
using System.IO;

namespace Chap03.LogAn
{
    public class LogAnalyzer
    {
        public IExtensionManager extentionManager;

        // constructor using DI
        public LogAnalyzer(IExtensionManager _manager)
        {
            extentionManager = _manager;
        }

        // constructor using FactoryMethod
        public LogAnalyzer()
        {
            extentionManager = ExtensionManagerFactory.Create();
        }

        public bool WasLastFileNameValid { get; set; }

        public bool IsValidLogFileName(string fileName)
        {
            return extentionManager.IsValid(fileName)
                && Path.GetFileNameWithoutExtension(fileName).Length > 5;
        }
    }
}
