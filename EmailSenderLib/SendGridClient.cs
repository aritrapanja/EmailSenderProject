using System;
using System.Net.Mail;
using System.Net.Mime;

namespace EmailSenderLib
{
    public class SendGridClient : IEmailSender
    {
        public SendGridClient()
        {
        }

        public ReturnItem SendMail(Request req)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                // To todo: extract a method.
                if(!string.IsNullOrWhiteSpace(req.To))
                {
                    foreach (var mailaddress in req.To.Split(';'))
                    {
                        mailMsg.To.Add(new MailAddress(mailaddress, ""));
                    }
                }

                // CC
                if(!string.IsNullOrWhiteSpace(req.Cc))
                {
                    foreach (var mailaddress in req.Cc.Split(';'))
                    {
                        mailMsg.CC.Add(new MailAddress(mailaddress, ""));
                    }
                }

                // BCC
                if (!string.IsNullOrWhiteSpace(req.Bcc))
                {
                    foreach (var mailaddress in req.Bcc.Split(';'))
                    {
                        mailMsg.Bcc.Add(new MailAddress(mailaddress, ""));
                    }
                }

                // From
                mailMsg.From = new MailAddress(req.From, "From Name");

                // Subject and  Body
                mailMsg.Subject = req.Subject;
                string text = req.Body;
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));

                // To Do: Keys will be replaced on the run time.
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("xxxxx@gmail.com", "I_AM_Not_Giving_you_The_Key");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
                return new ReturnItem
                {
                    Message = "Send mail from SendGridClient",
                    RetCode = 1
                };
            }
            catch (Exception ex)
            {
                return new ReturnItem
                {
                    Message = ex.ToString(),
                    RetCode = 2
                };
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
