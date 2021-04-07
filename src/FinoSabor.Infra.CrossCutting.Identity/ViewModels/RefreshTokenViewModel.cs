using System;

namespace FinoSabor.Infra.CrossCutting.Identity.ViewModels
{
    public class RefreshTokenViewModel
    {
        public RefreshTokenViewModel()
        {
            Token = Guid.NewGuid();
        }

        public Guid id { get; set; }
        public string Username { get; set; }
        public Guid Token{ get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
