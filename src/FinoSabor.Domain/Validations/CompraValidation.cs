using FluentValidation;
using FinoSabor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Domain.Validations
{
    public class CompraValidation : AbstractValidator<Compra>
    {
        public CompraValidation()
        {
            
        }
    }
}
