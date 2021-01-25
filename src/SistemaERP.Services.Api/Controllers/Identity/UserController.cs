using Microsoft.AspNetCore.Mvc;
using SistemaERP.Application.Notificacoes.Interface;
using SistemaERP.Infra.CrossCutting.Identity.Extensions.Interfaces;
using SistemaERP.Services.Api.Controllers.Base;

namespace SistemaERP.Services.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    public class UserController : MainController
    {


        public UserController(INotificador notificador, IAspNetUser appUser) : base(notificador, appUser)
        {
        }


        /*[HttpGet]
        public async Task<ActionResult> ObterTodos(int skip, int take)
        {
            return Ok();
            //return Ok(await _usuarioRepository.GetAll(skip, take));
        }*/



    }
}
