using FinoSabor.Domain.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Application.Imagem.Commands
{
    public class RemoverImagemCommand : IRequest<BaseResponse>
    {
        public RemoverImagemCommand(string caminhoImagem)
        {
            CaminhoImagem = caminhoImagem;
        }

        public string CaminhoImagem { get; set; }
    }
}
