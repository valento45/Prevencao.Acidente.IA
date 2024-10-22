using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prevencao.Acidente.IA.Core.Models.PreventionAcidente
{
    public class Acident
    {

        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public CondicaoClimatica Clima { get; set; }
        public Via Via { get; set; }

     


        public Acident()
        {
            DataHora = DateTime.Now;
            Clima = new CondicaoClimatica();
            Via = new Via();    
        }


        public Acident(CondicaoClimatica condicaoClimatica, Via via)
        {
            Clima = condicaoClimatica;
            Via = via;
        }
    }
}
