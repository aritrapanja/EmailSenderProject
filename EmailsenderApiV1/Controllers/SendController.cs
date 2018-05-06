using System.Collections.Generic;
using EmailsenderApiV1.Models;
using Microsoft.AspNetCore.Mvc;
using EmailSenderLib;
using System.Net.Http;

namespace EmailsenderApiV1.Controllers
{
    [Produces("application/json")]
    [Route("api/Send")]
    public class SendController : Controller
    {
        // GET: api/Send
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Send/5
        [HttpGet("{id}", Name = "Get")]
        public EmailRequestDAO Get(int id)
        {
            return new EmailRequestDAO();
        }
        
        // POST: api/Send
        [HttpPost]
        public ReturnItem Post([FromBody]Request value)
        {
            var sender = EmailsenderBuilder.GetNewEmailSenderPlain();

            return sender.SendMail(value);
        }
        
        // PUT: api/Send/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
