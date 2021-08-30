using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Core.Utilities.Mailer
{
    public class Mailer
    {
        private static readonly string defaultEmail = "beratyesbek@gmail.com";

        public static IFluentEmail StartMailer(string subject,string email)
        {
            var smtp = new SmtpSender(() => new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = defaultEmail,
                    Password = "zfskyvymqrpfkiez"
                }

            });

            Email.DefaultSender = smtp;

            var _email = Email.From(defaultEmail)
                .To(email)
                .Subject(subject);
               return _email;
        }
    }
}
