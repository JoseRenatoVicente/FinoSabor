using System.Threading.Tasks;

namespace SistemaERP.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendAsync(string to, string subject, string html, int tentativa = 1);
        Task Test(string email, string nome);
    }
}
