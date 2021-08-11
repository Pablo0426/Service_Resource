using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace EmailSender
{
    public class EmailUser
    {
        public void MailToUser(string persona, string Tema, string contenido)
        {
            Task.Run(()=> EnviarCorreo(persona, Tema, contenido));
        }

        private void EnviarCorreo(string persona, string Tema, string contenido)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(EmailInfo.Default.smtpClient);

                mail.From = new MailAddress(EmailInfo.Default.Email);
                mail.To.Add(persona);
                mail.Subject = Tema;
                mail.Body = contenido;

                smtpClient.Port = EmailInfo.Default.Port;
                smtpClient.Credentials = new NetworkCredential(EmailInfo.Default.Email, EmailInfo.Default.Password);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
            }
            catch (Exception)
            {

            }
        }
    }
}
