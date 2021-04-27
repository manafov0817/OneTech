using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OneTech.WebUi.EmailServices
{
    public class SmtpEmailSender : IEmailSender
    {
        private string _host;
        private int _port;
        private bool _enableSSL;
        private string _username;
        private string _password;
        public SmtpEmailSender(string host, int port, bool enableSSL, string username, string password)
        {
            _host = host;
            _port = port;
            _enableSSL = enableSSL;
            _username = username;
            _password = password;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = this._enableSSL
            };

            return client.SendMailAsync(
                new MailMessage(this._username, email, subject, htmlMessage)
                {
                    IsBodyHtml = true
                }
            );
        }
    }
}