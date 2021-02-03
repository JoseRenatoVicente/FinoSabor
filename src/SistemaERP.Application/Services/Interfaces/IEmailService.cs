using SistemaERP.Application.ViewModels;
using System.Threading.Tasks;

namespace SistemaERP.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string ToEmail, string Subject, string Body);
        
    }
}
