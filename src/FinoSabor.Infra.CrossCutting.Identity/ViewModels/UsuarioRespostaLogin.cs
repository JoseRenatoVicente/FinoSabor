using System;

namespace FinoSabor.Infra.CrossCutting.Identity.ViewModels
{
    public class UsuarioRespostaLogin
    {
        public string AccessToken { get; set; }
        public Guid RefreshToken { get; set; }
        public double ExpiresIn { get; set; }
        public string Nome { get; set; }
        public UsuarioToken UsuarioToken { get; set; }
    }
}
