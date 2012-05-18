using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClarkNN.Brain;

namespace ClarkNNTester
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork network = new NeuralNetwork(1);
            //network.createLayers(int layersCount)
            network.InputLayer.CreateNeurons(2);
            network.Layers[1].CreateNeurons(1.5, 0.5);
            network.OutputLayer.CreateNeuron(0.5);
            //network.Layers[0].CreateNeurons(double[] thresholds):Neurons[]
            //network.Layers[0].CreateNeurons(int neuronsCount): Neuron[]
            //network.Layers[0].AddNeurons(Neuron[] neurons)
            double[][] weights = {new double[]{1, 1, 1, 1}, new double[]{-1, 1} };
            network.CreateSynapses(weights);
            //network.InputLayer.SynapseTo(network.Layers[1], 1, 1, 1, 1);
            //network.Layers[1].SynapseTo(network.OutputLayer, -1, 1);
            //neurons[0].SynapseToLayer(network.Layers[1]).Weight = 1; 
            //neurons[1].SynapseToLayer(network.Layers[1]).Weight = 1; 
            double[] inputs = { 0, 1 };
            network.Inputs(inputs);
            Console.Write("La entrada fue "); Print(inputs);
            double[] outputs = network.Outputs();
            Console.Write("La salida fue "); Print(outputs); 

            Console.ReadKey();
        }


        public static void Print(double[] objects)
        {
            Console.Write("{");
            for(int i=0; i < objects.Length; i++) {
                if (i > 0) 
                    Console.Write(", ");
                Console.Write(objects[i]);
            }
            Console.WriteLine("}");
        }
    }
}
