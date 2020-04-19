using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;

namespace EmailWAtt.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            MailMessage mail = new MailMessage();

            //set the addresses
            mail.From = new MailAddress("ugbdho@gmail.com");
            mail.To.Add("sadiqur01@gmail.com");

            //set the content
            mail.Subject = "This is an email";
            mail.Body = "this content is in the body";

            //Get some binary data
            byte[] data = GetData();

            //save the data to a memory stream
            MemoryStream ms = new MemoryStream(data);

            //create the attachment from a stream. Be sure to name the data with a file and 
            //media type that is respective of the data
            mail.Attachments.Add( new Attachment(@"D:\clients.pdf"));

            //send the message
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(
                "ugbdho@gmail.com", "ugbdhoIT");
            smtpClient.Send(mail);
        
            
            return "value";
        }
        static byte[] GetData()
        {
            //this method just returns some binary data.
            //it could come from anywhere, such as Sql Server
            string s = "this is some text";
            byte[] data = Encoding.ASCII.GetBytes(s);
            return data;
        }
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
