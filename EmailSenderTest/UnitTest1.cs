using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmailSenderLib;

namespace EmailSenderTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MailGunTest()
        {
            MailGunClient mc = new MailGunClient();
            Request req = new Request
            {
                Body = "dfh",
                Subject = "gjh",
                From = "tdyugg@gmail.com",
                To = "tdddttd@gmail.com"
            };

            var ret = mc.SendMail(req);
            Assert.Equals(ret.RetCode, 1);
        }

        [TestMethod]
        public void SendGridTest()
        {
            SendGridClient sc = new SendGridClient();
            Request req = new Request
            {
                Body = "dfh",
                Subject = "gjh",
                From = "ijngdsr@gmail.com",
                To = "kjgfdssa@gmail.com"
            };

            Assert.Equals(sc.SendMail(req),2);
        }

        [TestMethod]
        public void EmailSenderTest()
        {
            EmailSender sc = EmailsenderBuilder.GetNewEmailSenderPlain();
            Request req = new Request
            {
                Body = "dfh",
                Subject = "gjh",
                From = "jgfsrg.com",
                To = "kljhgdds@gmail.com"
            };
            Assert.Equals(sc.SendMail(req), 2);
        }
    }
}
