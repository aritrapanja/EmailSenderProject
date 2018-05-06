using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmailSenderLibV2;

namespace EmailSenderTestV2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MailGunClientTest()
        {
            MailGunClient mc = new MailGunClient();
            var req = new Request();
            req.From = "arpanja@humtum.com";
            req.To = "aritra.nirvana@gmail.com";
            req.Subject = "testpoke";
            req.Body = " Hi, do you do? ";
            mc.SendMessage(req);
        }
    }
}
