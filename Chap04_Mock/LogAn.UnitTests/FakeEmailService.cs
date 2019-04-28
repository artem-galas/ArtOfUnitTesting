using System;

using Chap04.LogAn;

namespace Chap04.Tests
{
    public class FakeEmailService : IEmailService
    {
        public string To;
        public string Subject;
        public string Body;
        public void SendEmail(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}