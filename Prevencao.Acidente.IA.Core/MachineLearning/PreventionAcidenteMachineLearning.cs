using Microsoft.ML;
using Prevencao.Acidente.IA.Core.MachineLearning.Interfaces;
using Prevencao.Acidente.IA.Core.Models.PreventionAcidente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prevencao.Acidente.IA.Core.MachineLearning
{
    public class PreventionAcidenteMachineLearning : IPreventionAcidenteMachineLearning
    {
        private MLContext mlContext { get; set; }

        public PreventionAcidenteMachineLearning()
        {

            mlContext = CreateContext();
        }

        public MLContext CreateContext()
        {
           return new MLContext();      
        }


        /// <summary>
        /// 1. Specify data preparation and model training pipeline
        /// 2. Train model
        /// 3. Make a prediction
        /// 4. Predict
        /// </summary>
        /// <param name="clima"></param>
        /// <param name="via"></param>
        /// <param name="trainingData"></param>
        /// <returns></returns>

        public AcidentePrediction Predict(CondicaoClimatica clima, Via via, IDataView trainingData)
        {

            var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "Size" })
                .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "PercentePossivelAcidente", maximumNumberOfIterations: 100));


            var model = pipeline.Fit(trainingData);


            var climaVia = new Acident(clima, via);

            var resultPredict = mlContext.Model.CreatePredictionEngine<Acident, AcidentePrediction>(model).Predict(climaVia);
            return resultPredict;
        }


        public IDataView BuildTraining(IEnumerable<Prevencao.Acidente.IA.Core.Models.PreventionAcidente.Acident> acidentes)
        {
            return Training(mlContext, acidentes);
        }


        private IDataView Training(MLContext mlContext, IEnumerable<Prevencao.Acidente.IA.Core.Models.PreventionAcidente.Acident> acidentes)
        {
            if (mlContext == null)
                throw new ArgumentNullException(nameof(mlContext));


            IDataView trainingData = mlContext.Data.LoadFromEnumerable(acidentes);
            return trainingData;

        }
    }
}
