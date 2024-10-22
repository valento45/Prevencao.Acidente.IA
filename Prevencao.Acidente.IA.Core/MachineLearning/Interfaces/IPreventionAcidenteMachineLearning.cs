using Microsoft.ML;
using Prevencao.Acidente.IA.Core.Models.PreventionAcidente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prevencao.Acidente.IA.Core.MachineLearning.Interfaces
{
    public interface IPreventionAcidenteMachineLearning
    {
        AcidentePrediction Predict(CondicaoClimatica clima, Via via, IDataView trainingData);
        IDataView BuildTraining(IEnumerable<Prevencao.Acidente.IA.Core.Models.PreventionAcidente.Acident> acidentes);
    }
}
