using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaERP.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task Test(string email, string nome);

        Task SendEmailAsync(string email, string subject, string message);
        Task SendEmailsAsync(List<string> emails, string subject, string message);
    }
}
