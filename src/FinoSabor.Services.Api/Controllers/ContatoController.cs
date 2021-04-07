using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers
{
    public class ContatoController : MainController
    {
        public ContatoController(INotificador notificador, IAspNetUser appUser) : base(notificador, appUser)
        {
        }
    }
}
