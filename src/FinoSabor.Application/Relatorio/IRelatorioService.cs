using DinkToPdf;
using System.Threading.Tasks;

namespace FinoSabor.Application.Relatorio
{
    public interface IRelatorioService 
    {
        Task<byte[]> CreatePDF(GlobalSettings optionalGlobalSettings, ObjectSettings ObjectSettings);
    }
}
