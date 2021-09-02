using Entity.Concretes;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Core.Utilities.Mailer;
namespace Business.BusinessMailer
{
    public class PurchaseMailer
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "mailer";
        private static string purchaseHtmlPage = "PurchaseMailer.cshtml";

        private static readonly string subject = "Thank you for your payment";

        public static async void SendPurchaseMail(Payment payment)
        {
            var _email = Mailer.StartMailer(subject, payment.Email).
                UsingTemplateFromFile($"{_currentDirectory.Replace("\\", "/") + "/" + _folderName + "/" + purchaseHtmlPage}", new { address = payment.Address, name = payment.CardHolderName, price = payment.TotalPrice });
            await _email.SendAsync();
        }


    }
}
