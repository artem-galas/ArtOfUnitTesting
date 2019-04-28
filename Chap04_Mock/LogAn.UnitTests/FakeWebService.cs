using System;

using LogAn;

namespace Tests
{
    public class FakeWebService : IWebService
    {
        public Exception ToThrow;
        public void LogError(string message)
        {
            if (ToThrow != null) 
            {
                throw ToThrow;
            }
        }
    }
}