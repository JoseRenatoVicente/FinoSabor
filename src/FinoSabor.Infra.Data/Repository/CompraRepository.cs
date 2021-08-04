using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.ViewModels;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository
{
    public class CompraRepository : BaseRepository<Compra>, ICompraRepository
    {
        public CompraRepository(FinoSaborContext context) : base(context) { }
    }
}
