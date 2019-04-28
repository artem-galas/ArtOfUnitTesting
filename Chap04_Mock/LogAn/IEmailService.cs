namespace Chap04.LogAn
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
}