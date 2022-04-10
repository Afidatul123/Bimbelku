using Bimbelku.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Bimbelku.Services
{
    public class EmailService
    {
        private readonly IOptions<Email> _email;
        public EmailService(IOptions<Email> mail)
        {
            _email = mail;
        }
        public bool KirimEmail(string tujuan, string subjek, string isi)
        {
            try
            {
                Email em = new Email();
                em.Client = _email.Value.Client;
                em.Port = _email.Value.Port;
                em.AlamatEmail = _email.Value.AlamatEmail;
                em.PasswordEmail = _email.Value.PasswordEmail;

                MailMessage mm = new MailMessage();
                mm.From = new MailAddress(em.AlamatEmail);
                mm.Subject = subjek;
                mm.Body = isi;
                mm.IsBodyHtml = true;
                mm.To.Add(tujuan); 
                
                SmtpClient sc = new SmtpClient(em.Client);
                sc.Port = em.Port;
                sc.Credentials = new System.Net.NetworkCredential(em.AlamatEmail, em.PasswordEmail);
                sc.EnableSsl = true;
                sc.Send(mm);                                      

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
