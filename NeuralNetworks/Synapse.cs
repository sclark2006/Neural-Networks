using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarkNN.Brain
{

    public class Synapse 
    {
        private Neuron fromNeuron;
        private Neuron toNeuron;
        private double weight;
        private double inputValue;

        public Synapse(Neuron fromNeuron, Neuron toNeuron, double weight)
        {
            this.fromNeuron = fromNeuron;
            this.toNeuron = toNeuron;
            this.weight = weight;
            this.inputValue = 1;
        }

        public Synapse(Neuron fromNeuron, Neuron toNeuron)
        {
            this.fromNeuron = fromNeuron;
            this.toNeuron = toNeuron;
            this.weight = 1;
        }


        public double Input
        {
            set { inputValue = value; }
            get { return inputValue; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Neuron FromNeuron
        {
            get { return fromNeuron; }
        }

        public Neuron ToNeuron
        {
            get { return toNeuron; }
        }
    }

}
