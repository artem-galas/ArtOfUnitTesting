using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        private bool WasLastFileNameValid { get; set; }
        private IWebService _webService;
        private IEmailService _emailService;

        public LogAnalyzer(
            IWebService webService, 
            IEmailService emailService
        )
        {
            _webService = webService;
            _emailService = emailService;
        }

        public void Analyze(string fileName)
        {
            if(fileName.Length < 8)
            {
                try
                {
                    _webService.LogError($"Filename too short: {fileName}");
                } 
                catch(Exception e)
                {
                    _emailService.SendEmail(
                        to: "a@mail.com",
                        subject: "Can't log",
                        body: e.Message
                    );
                }
            } 
        }
    }
}
