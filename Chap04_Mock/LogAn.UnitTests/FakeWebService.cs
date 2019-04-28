using System;

using Chap04.LogAn;

namespace Chap04.Tests
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