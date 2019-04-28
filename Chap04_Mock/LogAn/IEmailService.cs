namespace LogAn
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
}