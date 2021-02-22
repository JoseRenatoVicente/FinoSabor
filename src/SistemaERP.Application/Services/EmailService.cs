using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;
using SistemaERP.Application.Services.Interfaces;
using SistemaERP.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SistemaERP.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfigRepository _emailConfigRepository;

        public EmailService(IEmailConfigRepository emailConfigRepository)
        {
            _emailConfigRepository = emailConfigRepository;
        }

        /*public async Task Execute(string to, string subject, string html)
        {
            if (!await SendAsync(to, subject, html)) await SendAsync(to, subject, html, 2);
        }
        public async Task<bool> SendAsync(string to, string subject, string html, int tentativa = 1)
        {

            try
            {

                var emailPrioridade = await _emailConfigRepository.PegarEmailPorPrioridade(tentativa);

                // create message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(emailPrioridade.Email));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = html };


                // send email
                using var smtp = new SmtpClient();
                smtp.Connect(emailPrioridade.Host, emailPrioridade.Porta, emailPrioridade.UsarSSL);
                smtp.Authenticate(emailPrioridade.Email, emailPrioridade.Senha);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
                return true;
            }

            catch (Exception e)
            {
                Log.Error("# " + e);                
                return false;
            }
        }*/


        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emails = new List<string>();
            emails.Add(email);
            await Execute("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", subject, message, emails);
        }

        public async Task SendEmailsAsync(List<string> emails, string subject, string message)
        {

            await Execute("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", subject, message, emails);
        }

        public async Task Execute(string apiKey, string subject, string message, List<string> emails)
        {

            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("tempforum333@gmail.com", "SistemaERP"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            foreach (var email in emails)
            {
                msg.AddTo(new EmailAddress(email));
            }

            var response = await client.SendEmailAsync(msg);

        }

        public async Task Test(string email, string nome)
        {
            var emails = new List<string>();
            emails.Add(email);
            var titulo = "SistemaERP - teste de email";
            var mensagem = $"<p>Olá {nome},</p> <p>Esse é um email de teste para verificar se o sistema consegue fazer contato com você. Por favor avise o facilitador quando esse email chegar. Obrigado.</p>";
            
            await SendEmailsAsync(emails, titulo, mensagem);
        }
        /*
        public async Task SendEmailAsync(string ParaEmail, string Titulo, string mensagem)
        {
            var emailPrioridade = await _emailConfigRepository.PegarEmailPorPrioridade(1);
            var email = new MimeMessage();
            email.To.Add(MailboxAddress.Parse(ParaEmail));
            email.Subject = Titulo;
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
            builder.HtmlBody = mensagem;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(emailPrioridade.Host, emailPrioridade.Porta, emailPrioridade.UsarSSL);
            smtp.Authenticate(emailPrioridade.Email, emailPrioridade.Senha);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }

        public async Task<List<EmailMessage>> ReceiveEmail(int maxCount = 10)
        {

            using (var emailClient = new Pop3Client())
            {
                var emailPrioridade = await _emailConfigRepository.PegarEmailPorPrioridade(1);
                emailClient.Connect(emailPrioridade.Host, emailPrioridade.Porta, true);

                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(emailPrioridade.Email, emailPrioridade.Senha);

                List<EmailMessage> emails = new List<EmailMessage>();
                for (int i = 0; i < emailClient.Count && i < maxCount; i++)
                {
                    var message = emailClient.GetMessage(i);
                    var emailMessage = new EmailMessage
                    {
                        Content = !string.IsNullOrEmpty(message.HtmlBody) ? message.HtmlBody : message.TextBody,
                        Subject = message.Subject
                    };
                    emailMessage.ToAddresses.AddRange(message.To.Select(x => (MailboxAddress)x).Select(x => new EmailAddress { Address = x.Address, Name = x.Name }));
                    emailMessage.FromAddresses.AddRange(message.From.Select(x => (MailboxAddress)x).Select(x => new EmailAddress { Address = x.Address, Name = x.Name }));
                    emails.Add(emailMessage);
                }

                return emails;
            }
        }

        /*public async Task Send(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;
            //We will say we are sending HTML. But there are options for plaintext etc. 
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content
            };

            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                var emailPrioridade = await _emailConfigRepository.PegarEmailPorPrioridade(1);
                //The last parameter here is to use SSL (Which you should!)
                emailClient.Connect(emailPrioridade.Host, emailPrioridade.Porta, true);

                //Remove any OAuth functionality as we won't be using it. 
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(emailPrioridade.Email, emailPrioridade.Senha);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }

        }*/

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
                var email = await _emailConfigRepository.PegarEmailPorPrioridade(1);
                using (var client = new SmtpClient())
                {
                    if (email.UsarSSL)
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    }

                    client.Connect(email.Host, email.Porta, email.UsarSSL);
                    client.Authenticate(email.Email, email.Senha);
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
            //message.From.Add(new MailboxAddress());
            message.To.Add(MailboxAddress.Parse(emailRecipient));

            if (copyAdmins)
            {
                //var adminsEmails = GetAdminEmails();
                //message.Cc.AddRange(adminsEmails);
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
        */


    }
}
