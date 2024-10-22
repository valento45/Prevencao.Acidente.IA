using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prevencao.Acidente.IA.Core.Models.PreventionAcidente
{
    public class Via
    {
        public bool HasObras { get; set; }
        public bool HasMataAnimaisSelvagem { get; set; }
        public bool HasPassarelaPessoas { get; set; }
        public bool HasAcostamento { get; set; }
        public int LimiteVelocidade { get; set; }

    }
}
