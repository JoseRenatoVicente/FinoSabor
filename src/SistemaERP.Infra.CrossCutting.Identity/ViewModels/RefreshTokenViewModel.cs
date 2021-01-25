using SistemaERP.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaERP.Infra.CrossCutting.Identity.ViewModels
{
    public class RefreshTokenViewModel : EntityBase
    {
        public RefreshTokenViewModel()
        {
            Token = Guid.NewGuid();
        }


        public string Username { get; set; }
        public Guid Token{ get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
