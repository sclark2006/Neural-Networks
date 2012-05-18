using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarkNN.Brain
{
    public class Layer : List<Neuron>
    {
        public Layer() {}

        public Layer(int neuronsCount)
        {
            for (int i = 0; i < neuronsCount; i++)
            {
                Add(new Neuron());
            }
        }
        
        public void AddNeurons(Neuron[] neurons)
        {
            for (int i = 0; i < neurons.Length; i++)
            {
                Add(neurons[i]);
            }
        }

        public Neuron[] CreateNeurons(int neuronsCount)
        {
            Neuron[] neurons = new Neuron[neuronsCount];
            for (int i = 0; i < neuronsCount; i++)
            {
                neurons[i] = new Neuron();
                Add(neurons[i]);
            }
            return neurons;
        }

        public Neuron CreateNeuron(double theshold)
        {
            Neuron neuron = new Neuron(theshold);
            Add(neuron);
            return neuron;
        }

        public Neuron[] CreateNeurons(params double[] thresholds)
        {
            Neuron[] neurons = new Neuron[thresholds.Length];
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i] = new Neuron(thresholds[i]);
                Add(neurons[i]);
            }
            return neurons;
        }

        public Synapse[] SynapseTo(Layer layer)
        {
            Synapse[] synapses = new Synapse[this.Count * layer.Count];
            int i = 0;
            foreach (Neuron fromNeuron in this)
            {
                foreach (Neuron toNeuron in layer)
                {
                    synapses[i] = fromNeuron.SynapseTo(toNeuron);
                    i++;
                }
            }
            return synapses;
        }


        public Synapse[] SynapseTo(Layer destinationLayer, params double[] weights)
        {
            if (weights.Length != this.Count * destinationLayer.Count)
                throw new Exception("The size of the weights matrix must correspond to the product of the count of neurons in this layer by neurons in the destination layer");

            Synapse[] synapses = new Synapse[weights.Length];
            int i=0;

            foreach (Neuron fromNeuron in this)
            {
                foreach (Neuron toNeuron in destinationLayer)
                {
                    synapses[i] = fromNeuron.SynapseTo(toNeuron);
                    synapses[i].Weight = weights[i];
                    i++;
                }
            }

            return synapses;
        }

        public void Inputs(double[] inputValues)
        {
            if (inputValues.Length == this.Count)
            {               
                for (int i = 0; i < this.Count; i++)
                {
                    //if(this[i].InputSynapses.Count == 0)
                    //    this[i].InputSynapses.Add(new Synapse(
                    //this[i].InputSynapses.ElementAt(i).Input = inputValues[i];
                    this[i].Input = inputValues[i];
                }
            }
        }

        public double[] Outputs()
        {
            double[] outputs = new double[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                outputs[i] = this[i].Output();
            }
            return outputs;
        }

    }//class
}
