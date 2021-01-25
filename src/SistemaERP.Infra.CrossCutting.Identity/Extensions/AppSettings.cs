namespace SistemaERP.Infra.CrossCutting.Identity.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
        public string AutenticacaoJwksUrl { get; set; }
    }
}
