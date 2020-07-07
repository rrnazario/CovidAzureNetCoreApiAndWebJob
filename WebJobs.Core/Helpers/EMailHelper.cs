using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CovidStatus.WebJob.Core.Helpers
{
    public class EmailHelper
    {
        public static void SendMail(string from, string to, string subject, string message)
        {
            var client = new SendGridClient(EnvironmentHelper.GetInfoFromConfig("sendGridToken"));

            var fromMail = new EmailAddress(string.IsNullOrEmpty(from) ? EnvironmentHelper.GetInfoFromConfig("defaultFromMail") : from);

            var toMails = (string.IsNullOrEmpty(to) ? EnvironmentHelper.GetInfoFromConfig("toMails") : to)
                          .Split(',')
                          .Select(s => new EmailAddress(s.Trim()));
            try
            {
                var multiMessage = MailHelper.CreateMultipleEmailsToMultipleRecipients(fromMail, toMails.ToList(), new List<string>(Enumerable.Repeat(subject, toMails.Count())), string.Empty, message.ToString(), null);

                client.SendEmailAsync(multiMessage).GetAwaiter().GetResult();
            }
            catch (Exception)
            {
                foreach (var mail in toMails)
                {
                    var msg = MailHelper.CreateSingleEmail(fromMail, mail, subject, string.Empty, message);

                    client.SendEmailAsync(msg).GetAwaiter().GetResult();
                }
            }
        }
    }
}
