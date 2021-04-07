using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Services.Base;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Helpers;
using FinoSabor.Domain.Validations;
using FinoSabor.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Application.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(INotificador notificador,
                                ICategoriaRepository categoriaRepository
            ) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _categoriaRepository.GetAllAsync();
        }
        public async Task<Categoria> ObterCategoriaPorId(Guid id)
        {
            return await _categoriaRepository.GetByIdAsync(id);
        }

        public async Task<bool> Adicionar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return false;

            if (await _categoriaRepository.Existe(c => c.slug == categoria.slug))
            {
                Notificar("Já existe uma categoria com o nome " + categoria.nome);
                return false;
            }

            categoria.slug = categoria.nome.Slugify();

            await _categoriaRepository.AddAsync(categoria);
            return true;
        }

        public async Task<bool> Atualizar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return false;

            categoria.slug = categoria.nome.Slugify();

            await _categoriaRepository.UpdateAsync(categoria);
            return true;
        }
        public async Task<bool> Remover(Guid id)
        {
            await _categoriaRepository.DeleteAsync(id);
            return true;
        }
        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }
    }
}
