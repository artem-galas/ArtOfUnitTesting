using System;

using NUnit.Framework;
using NSubstitute;

using Chap05.LogAn;

namespace Chap05.Tests
{
    public class LogAnalyzer2Tests
    {
        [Test]
        public void Analyze_LoggerThrows_CallsWebService()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger
                .When(logger => logger.LogError(Arg.Any<string>()))
                .Do(info => throw new Exception("fake exception"));
            
            var logAnalyzer = new LogAnalyzer2(stubLogger, mockWebService);

            logAnalyzer.MinNameLength = 10;
            logAnalyzer.Analyze("short.txt");

            mockWebService.Received()
                .Write(Arg.Is<string>(s => s.Contains("fake exception")));
        }
    }
}