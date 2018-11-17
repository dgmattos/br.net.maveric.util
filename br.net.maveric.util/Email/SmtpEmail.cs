using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace br.net.maveric.util.Email
{
    public class SmtpEmail
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public System.Net.NetworkCredential Credentials { get; set; }
        public string e_mail_from { get; set; }
        private string email { get; set; }

        private System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        private System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

        public string htmlBody { get; set; }

        public string mailErro { get; set; }

        public SmtpEmail(string email, string senha)
        {
            MailAddress e = new MailAddress(email);
            this.email = email;
            this.Credentials = new System.Net.NetworkCredential(email, senha);
            this.Port = 587;
            this.EnableSsl = false;
            this.UseDefaultCredentials = false;
            this.Host = "mail." + e.Host;

            e_mail_from = email;

            this.SMTPConnection();
        }

        public SmtpEmail(string Host, string email, string senha)
        {
            MailAddress e = new MailAddress(email);
            this.email = email;
            this.Credentials = new System.Net.NetworkCredential(email, senha);
            this.Port = 587;
            this.EnableSsl = true;
            this.UseDefaultCredentials = false;
            this.Host = Host;

            this.SMTPConnection();
        }

        public SmtpEmail(string Host, int Port, bool EnableSsl, System.Net.NetworkCredential Credentials)
        {

            this.Credentials = Credentials;
            this.Port = Port;
            this.EnableSsl = EnableSsl;
            this.UseDefaultCredentials = UseDefaultCredentials;
            this.Host = Host;
            this.email = email;

            this.SMTPConnection();
        }

        public SmtpEmail(string Host, string email, string senha, bool UseDefaultCredentials, bool EnableSsl)
        {

            this.Credentials = new System.Net.NetworkCredential(email, senha);
            this.Port = 587;
            this.EnableSsl = EnableSsl;
            this.UseDefaultCredentials = UseDefaultCredentials;
            this.Host = Host;
            this.email = email;
            this.SMTPConnection();
        }


        private void SMTPConnection()
        {

            try
            {
                smtp.Host = this.Host;
                smtp.Port = this.Port;
                smtp.EnableSsl = this.EnableSsl;
                smtp.UseDefaultCredentials = this.UseDefaultCredentials;

                if (!this.UseDefaultCredentials)
                {
                    smtp.Credentials = this.Credentials;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível conectar ao servidor SMTP.", ex);
            }
        }

        public bool EnviarHtml(string Email, string Nome, string Assunto, string htmlbody)
        {

            try
            {
                mail.From = new MailAddress(email, e_mail_from);
                mail.To.Add(Email);
                mail.Subject = Assunto;
                mail.IsBodyHtml = true;
                mail.Body = htmlbody;
                mail.ReplyToList.Add(new MailAddress(e_mail_from));
                this.smtp.Send(this.mail);

                return true;
            }
            catch (Exception ex)
            {
                this.mailErro = ex.Message;
                return false;
            }

        }

        public void getHtmlBody(string Url)
        {

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            this.htmlBody = result;
        }
    }
}
