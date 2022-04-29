using FinoSabor.Domain.Core.Responses;
using FinoSabor.Domain.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Application.Imagem.Commands
{
    public class MudarImagemPrincipalCommand : Command
    {
        public MudarImagemPrincipalCommand(string caminhoImagem)
        {
            CaminhoImagem = caminhoImagem;
        }

        public string CaminhoImagem { get; set; }
    }
}
