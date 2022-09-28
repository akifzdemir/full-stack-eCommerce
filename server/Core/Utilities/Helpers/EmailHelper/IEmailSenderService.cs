namespace Core.Utilities.Helpers.EmailHelper
{
    public interface IEmailSenderService
    {
        void SendEmail(string recipientEmail,string message,string subject);
    }
}
