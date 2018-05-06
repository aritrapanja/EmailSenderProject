namespace EmailSenderLib
{
    public class RequestBase
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }

        public RequestBase(string to, string from, string cc, string bcc, string body, string subject)
        {
            this.To = to;
            this.From = from;
            this.Cc = cc;
            this.Bcc = bcc;
            this.Body = body;
            this.Subject = subject;
        }

        public RequestBase()
        {
        }

        public string Display()
        {
            return string.Format("to=>{0} from=>{1} cc=>{2} bcc=>{3} body=>{4} subject=>{5}", To, From, Cc, Bcc, Body, Subject);
        }
    }
}