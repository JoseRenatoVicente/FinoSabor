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
                if (optionalGlobalSettings is null)
                    optionalGlobalSettings = new GlobalSettings();

                if (optionalGlobalSettings.ColorMode is null)
                    optionalGlobalSettings.ColorMode = ColorMode.Color;

                if (optionalGlobalSettings.Orientation is null)
                    optionalGlobalSettings.Orientation = Orientation.Portrait;

                if (optionalGlobalSettings.PaperSize is null)
                    optionalGlobalSettings.PaperSize = PaperKind.A4;

                if (optionalGlobalSettings.DocumentTitle is null)
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
