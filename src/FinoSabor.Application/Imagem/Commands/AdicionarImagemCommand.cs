using FinoSabor.Domain.Core.Responses;
using FinoSabor.Domain.Messages;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Application.Imagem.Commands
{
    public class AdicionarImagemCommand : Command
    {
        public AdicionarImagemCommand(Guid produtoId, IFormFile file, bool imagemPrincipal)
        {
            ProdutoId = produtoId;
            File = file;
            ImagemPrincipal = imagemPrincipal;
        }

        public Guid ProdutoId { get; set; }
        public IFormFile File { get; set; }
        public bool ImagemPrincipal { get; set; } = true;
    }
}
