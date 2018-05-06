using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderLib
{
    public class EmailSender : IEmailSender
    {
        public IEmailSender PrimaryClient { get; set; }
        public List<IEmailSender> ScondaryClientList { get; set; }
        public IInputValidator InputValidator { get; set; }
        public IRetry RetryHandler { get; set; }
        //ILogger _logger;

        public ReturnItem SendMail(Request req)
        {
            var validationErrors = InputValidator.ValidateInputs(req);

            if (validationErrors.Count == 0)
            {
                var retCode = PrimaryClient.SendMail(req);

                if (retCode.RetCode == 1)
                {
                    return retCode;
                }
                else
                {
                    return RetryHandler.Retry(req, ScondaryClientList, retCode.Message);
                }
            }
            else
            {
                return new ReturnItem
                {
                    Message = string.Join(";",validationErrors.ToArray()),
                    RetCode = 3
                };
            }
        }
    }
}
