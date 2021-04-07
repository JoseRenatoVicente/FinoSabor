using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(FinoSaborContext context) : base(context) { }
    }
}
