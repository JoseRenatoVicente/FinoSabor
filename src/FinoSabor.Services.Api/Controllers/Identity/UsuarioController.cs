using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Domain.Helpers;
using FinoSabor.Domain.ViewModels.Pessoa;
using FinoSabor.Infra.Data.Repository.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

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
            IMapper mapper,
            UserManager<Usuario> userManager)
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
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        [HttpGet("UsuariosAdmin")]
        public async Task<PagedList<PessoaViewModel>> UsuariosAdmin(int PagNumero = 1, int PagRegistro = 10, string busca = null)
        {
            return await _pessoaRepository.PaginacaoGetAllAdminAsync(PagNumero, PagRegistro, busca);
        }

        [HttpGet("UsuariosComuns")]
        public async Task<PagedList<PessoaViewModel>> UsuariosComuns(int PagNumero = 1, int PagRegistro = 10, string busca = null)
        {
            return await _pessoaRepository.PaginacaoGetAllClientesAsync(PagNumero, PagRegistro, busca);
        }

    }
}
