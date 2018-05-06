namespace EmailSenderLib
{
    public interface IEmailSender
    {
        ReturnItem SendMail(Request req);
    }
}