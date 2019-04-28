using System;

using NUnit.Framework;

using Chap04.LogAn;

namespace Chap04.Tests
{
    public class LogAnalyzerTests
    {

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            var stubService = new FakeWebService {
                ToThrow = new Exception("fake exception")
            };

            var mockEmail = new FakeEmailService();

            var  logAnalyzer = new LogAnalyzer(stubService, mockEmail);
            string tooShortFileName = "abc.ext";

            logAnalyzer.Analyze(tooShortFileName);

            StringAssert.Contains("a@mail.com", mockEmail.To);
            StringAssert.Contains("Can't log", mockEmail.Subject);
            StringAssert.Contains("fake exception", mockEmail.Body);
        }
    }
}