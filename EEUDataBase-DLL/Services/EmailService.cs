﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEUDataBase_DLL.Services
{
    public class EmailService: IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Credentials:
            var credentialUserName = ""; //fill out later
            var sentFrom = "no-reply@eeu.dk";
            var sendGridPassword = ""; //fill out later

            // Configure the client:
            var client =
            new System.Net.Mail.SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));

            client.Port = 587;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            // Create the credentials:
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(credentialUserName, sendGridPassword);
            client.EnableSsl = true; client.Credentials = credentials;

            // Create the message: 
            var mail = new System.Net.Mail.MailMessage(sentFrom, message.Destination); 
            mail.Subject = message.Subject;
            mail.Body = message.Body;

            // Send: 
            return client.SendMailAsync(mail);
        }
    }
}
