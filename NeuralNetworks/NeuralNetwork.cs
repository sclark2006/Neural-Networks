using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarkNN.Brain
{
    public class NeuralNetwork
    {
        

        private List<Layer> layersList;

        public NeuralNetwork() : this(0)
        {            
        }

        public NeuralNetwork(int middleLayers)
        {
            this.layersList = new List<Layer>(middleLayers + 2);
            for (int i = 0; i < middleLayers + 2; i++)
            {
                this.layersList.Add(new Layer());
            }
        }

        public NeuralNetwork(int middleLayers, int inputNeurons, double[][] thresholds, double[][] weights)
        {

        }

        public NeuralNetwork(List<Layer>  layers)
        {
            this.layersList = layers;
        }

        public List<Layer> Layers
        {
            get
            {
                return this.layersList;
            }
        }

        public void CreateSynapses(double[][] weights)
        {
            for(int i=0; i < layersList.Count - 1; i++) {
                layersList[i].SynapseTo(layersList[i + 1],weights[i]);
            }

        }

        public void Inputs(double[] inputValues)
        {
            this.Layers.First().Inputs(inputValues);
        }
        
        public double[] Outputs()
        {            
            double[] outputs = null;
            foreach (Layer layer in Layers)
            {
                outputs = layer.Outputs();                
            }
            return outputs;
        }

        public Layer InputLayer
        {
            get
            {
                return this.layersList.First();
            }
        }

        public Layer OutputLayer
        {
            get
            {
                return this.layersList.Last();
            }
        }
    }
}
