namespace Chap05.LogAn
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
}