using System.Collections.Generic;

namespace EmailSenderLib
{
    public interface IRetry
    {
        ReturnItem Retry(Request req, List<IEmailSender> retryClientList, string InitialfailureMessage);
    }
}