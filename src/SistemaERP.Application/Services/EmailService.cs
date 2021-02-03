using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SistemaERP.Application.Services.Interfaces;
using SistemaERP.Application.ViewModels;
using System.IO;
using System.Threading.Tasks;

namespace SistemaERP.Application.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string ToEmail, string Subject, string Body)
        {
            var email = new MimeMessage();
            //email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(ToEmail));
            email.Subject = Subject;
            var builder = new BodyBuilder();
            /*if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
        builder.HtmlBody = Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        */}
        /*
        public async Task SendWelcomeEmailAsync(WelcomeRequest request)
        {
            string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\WelcomeTemplate.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();
            MailText = MailText.Replace("[username]", request.UserName).Replace("[email]", request.ToEmail);
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(request.ToEmail));
            email.Subject = $"Welcome {request.UserName}";
            var builder = new BodyBuilder();
            builder.HtmlBody = MailText;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task SendToAdmins(string messageText, string subject)
        {
            await Send(_settings.Username, "Administradores Sharebook", messageText, subject, true);
        }

        public async Task Send(string emailRecipient, string nameRecipient, string messageText, string subject)
            => await Send(emailRecipient, nameRecipient, messageText, subject, false);

        public async Task Send(string emailRecipient, string nameRecipient, string messageText, string subject, bool copyAdmins = false)
        {
            var message = FormatEmail(emailRecipient, nameRecipient, messageText, subject, copyAdmins);
            try
            {
                using (var client = new SmtpClient())
                {
                    if (_settings.UseSSL)
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    }

                    client.Connect(_settings.HostName, _settings.Port, _settings.UseSSL);
                    client.Authenticate(_settings.Username, _settings.Password);
                    await client.SendAsync(message);
                    client.Disconnect(true);
                }
            }
            catch (System.Exception e)
            {
                //TODO: v2 implementar log para exceptions
                throw e;

            }
        }

        private MimeMessage FormatEmail(string emailRecipient, string nameRecipient, string messageText, string subject, bool copyAdmins)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SistemaERP", _settings.Username));
            message.To.Add(new MailboxAddress(nameRecipient, emailRecipient));

            if (copyAdmins)
            {
                var adminsEmails = GetAdminEmails();
                message.Cc.AddRange(adminsEmails);
            }

            message.Subject = subject;
            message.Body = new TextPart("HTML")
            {
                Text = messageText
            };
            return message;
        }

        private InternetAddressList GetAdminEmails()
        {
            var admins = _userRepository.Get()
                .Select(u => new User
                {
                    Email = u.Email,
                    Profile = u.Profile
                }
                )
                .Where(u => u.Profile == Domain.Enums.Profile.Administrator)
                .ToList();

            InternetAddressList list = new InternetAddressList();
            foreach (var admin in admins)
            {
                list.Add(new MailboxAddress(admin.Email));
            }

            return list;
        }

        public async Task Test(string email, string name)
        {
            var subject = "Sharebook - teste de email";
            var message = $"<p>Olá {name},</p> <p>Esse é um email de teste para verificar se o sharebook consegue fazer contato com você. Por favor avise o facilitador quando esse email chegar. Obrigado.</p>";
            await this.Send(email, name, message, subject);
        }*/

    }
}
