﻿using System.Collections.Generic;

namespace FinoSabor.Domain.Helpers
{
    public class PagedList<T> where T : class
    {
        public int NumeroPagina { get; set; }
        public int RegistroPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
