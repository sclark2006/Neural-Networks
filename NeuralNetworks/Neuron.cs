using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarkNN.Brain
{


    public class Neuron
    {
        private double threshold;
        private double inputValue;
        private ActivationFunction activation;

        private ISet<Synapse> inputSynapses;
        private ISet<Synapse> outputSynapses;

        public Neuron():this(0.0)
        {
        }

        public Neuron(double threshold)
        {
            this.inputValue = 0.0;
            this.threshold = threshold;
            this.inputSynapses = new HashSet<Synapse>();
            this.outputSynapses = new HashSet<Synapse>();
            this.activation = ActivationType.Step;
        }

        public Synapse SynapseTo(Neuron neuron)
        {
            Synapse synapse = new Synapse(this, neuron);
            this.outputSynapses.Add(synapse);
            neuron.inputSynapses.Add(synapse);
            return synapse;
        }

        public double Input
        {
            //get { return this.inputValue; }
            set { this.inputValue = value; }
        }

        public double Threshold
        {
            set { this.threshold = value; }
            get { return this.threshold; }
        }

        public ISet<Synapse> InputSynapses
        {
            get { return inputSynapses; }
        }

        public ISet<Synapse> OutputSynapses
        {
            get { return outputSynapses; }
        }

        public ActivationFunction Activation
        {
            set { this.activation = value; }
            get { return this.activation; }
        }

        public double Output()
        {
            double sumOfWeightedInputs = inputValue;
            if (this.inputSynapses.Count > 0)
                sumOfWeightedInputs = inputSynapses.Sum(syn => (syn.Input * syn.Weight)); 

            //Activation Function
            //activationValue = inputValue > threshold ? 1 : 0;
            double activationValue = activation.Invoke(sumOfWeightedInputs, threshold);
            //Transmit the Output to the other synapses
            foreach (Synapse synapse in outputSynapses)
            {
                synapse.Input = activationValue;
            }
            return activationValue;


        }

    }//class

}//namespace