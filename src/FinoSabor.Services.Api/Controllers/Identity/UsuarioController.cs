using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using FinoSabor.Infra.Data.Repository.Interfaces;
using FinoSabor.Domain.ViewModels.Pessoa;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinoSabor.Services.Api.Controllers.Identity
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UsuarioController : MainController
    {
        private readonly IPessoaRepository _pessoaRepository;

        private readonly UserManager<Usuario> _userManager;

        private readonly IMapper _mapper;
        public UsuarioController(IPessoaRepository pessoaRepository,
            INotificador notificador, IAspNetUser appUser,
            IMapper mapper,
                                 UserManager<Usuario> userManager) : base(notificador, appUser)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
            _userManager = userManager;
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PessoaDetalhesViewModel>> ObterPorId(Guid id)
        {
            return await (await _pessoaRepository.GetAllAsync())
            .ProjectTo<PessoaDetalhesViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.id == id);

        }

        [HttpGet("UsuariosAdmin")]
        public async Task<IEnumerable<PessoaViewModel>> UsuariosAdmin()
        {
            return await _pessoaRepository.GetAllAdmins();
        }

        [HttpGet("UsuariosComuns")]
        public async Task<IEnumerable<PessoaViewModel>> UsuariosComuns()
        {
            return await _pessoaRepository.GetAllComuns();
        }

    }
}
