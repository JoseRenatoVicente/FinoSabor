namespace SistemaERP.Services.Api
{
    public static class Settings
    {

        public static string Secret = "Chave super hiper secreta hahahahahahahah";

        public static int ExpiracaoHoras = 2;

        public static string Emissor = "MeuSistema";

        public static string ValidoEm = "https://localhost";

        public static string ConnectionString = "Server=tcp:sistemaerp.database.windows.net,1433;Initial Catalog=SistemaERP.Services.Api_db;Persist Security Info=False;User ID=postgres;Password=A$%40pEt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
