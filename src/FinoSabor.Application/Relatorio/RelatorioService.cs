using DinkToPdf;
using DinkToPdf.Contracts;
using System.Threading.Tasks;

namespace FinoSabor.Application.Relatorio
{
    public class RelatorioService : IRelatorioService
    {
        private IConverter _converter;

        public RelatorioService(IConverter converter)
        {
            _converter = converter;
        }
                

        public Task<byte[]> CreatePDF(GlobalSettings optionalGlobalSettings, ObjectSettings ObjectSettings)
        {

            return Task.Run(() =>
            {
                if (optionalGlobalSettings == null)
                    optionalGlobalSettings = new GlobalSettings();

                if (optionalGlobalSettings.ColorMode == null)
                    optionalGlobalSettings.ColorMode = ColorMode.Color;

                if (optionalGlobalSettings.Orientation == null)
                    optionalGlobalSettings.Orientation = Orientation.Portrait;

                if (optionalGlobalSettings.PaperSize == null)
                    optionalGlobalSettings.PaperSize = PaperKind.A4;

                if (optionalGlobalSettings.DocumentTitle == null)
                    optionalGlobalSettings.DocumentTitle = "Relatório";

                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = optionalGlobalSettings,
                    Objects = { ObjectSettings }
                };

                return _converter.Convert(pdf);

            });
            
        }
    }
}
