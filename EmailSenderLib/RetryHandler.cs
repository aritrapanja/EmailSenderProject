using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderLib
{
    internal class RetryHandler : IRetry
    {

        public ReturnItem Retry(Request req, List<IEmailSender> retryClientList, string InitialfailureMessage)
        {
            var sb = new StringBuilder();
            foreach ( var c in retryClientList)
            {
               var retCode = c.SendMail(req);

                if(retCode.RetCode == 1)
                {
                    return retCode;
                }
                sb.Append(retCode.Message);
                
            }
            return new ReturnItem
            {
                Message = sb.ToString(),
                RetCode = 2
            };
        }
    }
}
