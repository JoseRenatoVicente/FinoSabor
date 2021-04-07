using AutoMapper;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Services.Base;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Validations;
using FinoSabor.Domain.ViewModels;
using FinoSabor.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Application.Services
{
    public class CompraService : BaseService, ICompraService
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IMapper _mapper;

        public CompraService(INotificador notificador,
                             IMapper mapper,
                             ICompraRepository compraRepository) : base(notificador)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompraViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CompraViewModel>>(await _compraRepository.GetAllAsync());
        }
        public async Task<CompraViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<CompraViewModel>(await _compraRepository.GetByIdAsync(id));
        }

        public async Task<bool> Adicionar(Compra compra)
        {
            await _compraRepository.AddAsync(compra);
            return true;
        }

        public async Task<bool> Atualizar(Compra compra)
        {
            await _compraRepository.UpdateAsync(compra);
            return true;
        }
        public async Task<bool> Remover(Guid id)
        {
            await _compraRepository.DeleteAsync(id);
            return true;
        }
        public void Dispose()
        {
            _compraRepository?.Dispose();
        }
    }
}
