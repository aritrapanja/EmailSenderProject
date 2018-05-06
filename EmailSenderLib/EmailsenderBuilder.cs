using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderLib
{
    public class EmailsenderBuilder
    {
        public static EmailSender GetNewEmailSenderPlain()
        {
            var es = new EmailSender
            {
                InputValidator = new Inputvalidator(),
                PrimaryClient = new SendGridClient(),
                ScondaryClientList = new List<IEmailSender>()
            {
                new MailGunClient()
            },
                RetryHandler = new RetryHandler()
            };
            return es;
        }

        public static EmailSender GetNewEmailSenderFromXml(string xml)
        {
            throw new NotImplementedException();
        }
    }
}
