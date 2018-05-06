using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderLib
{
    public class MailGunClient : IEmailSender
    {
        private static readonly string BaseUrlString = "https://api.mailgun.net/v3";

        // To Do: Keys will be replaced on the run time.
        private static readonly string ApiKey = "DO_YOU_THINK_I_WILL_GIVE_YOU_THE_KEY?";

        public IRestResponse SendMessage(Request req)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri(BaseUrlString);
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                                            ApiKey);
            RestRequest request = new RestRequest();

            // To Do: Keys will be replaced on the run time.
            request.AddParameter("domain", "blahblah", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", req.From);
            request.AddParameter("to", req.To);
            request.AddParameter("bcc", req.Bcc);
            request.AddParameter("subject", req.Subject);
            request.AddParameter("text", req.Body);
            request.Method = Method.POST;
            return client.Execute(request);
        }

        public ReturnItem SendMail(Request req)
        {
            var res = SendMessage(req);
            if (res.IsSuccessful)
            {
                return new ReturnItem
                {
                    Message = "Send mail from MailGunClient",
                    RetCode = 1
                };
            }
            else
            {
                return new ReturnItem
                {
                    // The response has inner exceptions
                    // To Do: Parse the exceptions.
                    Message = res.ErrorMessage,
                    RetCode = 2
                };
            }
        }
    }
}
