using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Application.ViewModels
{
    public class RecoveryRequest
    {
        public string ToEmail { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
