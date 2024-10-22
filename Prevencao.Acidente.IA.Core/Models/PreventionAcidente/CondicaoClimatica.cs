using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prevencao.Acidente.IA.Core.Models.PreventionAcidente
{
    public class CondicaoClimatica
    {
        public decimal Temperatura { get; set; }
        public bool HasChuva { get; set; }
        public bool HasQueimada { get; set; }

    }
}
