using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarkNN.Brain
{
    public struct ActivationType
    {
        public static ActivationFunction Sigmoid = (i, t) => 1 / (1 + Math.Exp((-i) / t));

        public static ActivationFunction HyperbolicTangent = (i, t) => (Math.Exp(t * 2.0) - i) / (Math.Exp(t * 2.0) + i);

        public static ActivationFunction Linear = (i, t) => t;

        public static ActivationFunction Step = (i, t) => i > t ? 1 : 0;

    }

    public delegate double ActivationFunction(double totalInput, double threshold);

}
