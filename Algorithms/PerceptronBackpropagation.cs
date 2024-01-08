

public class PerceptronBackpropagation
{
    private readonly double _learningRate;
    private NetworkArchtecture _network;
    private double _error;
    public PerceptronBackpropagation(NetworkArchtecture archtecture, double learningRate)
    {
        _network = archtecture;
        _learningRate = learningRate;
    }

    public double[] FeedForward(double[] inputs)
    {
        double[] output = inputs;
        foreach (var item in _network.Layers)
        {
            Print(output);

            var sum = item.SumUp(output);
            output = item.ActivationFunction(sum);
        }
        Print(output);

        return output;
    }

    internal void Train(double[] inputs, int expected)
    {
        var prediction = FeedForward(inputs).Sum();
        _error = expected - prediction;
        double outputActivationDerivative = 1 - expected ^ 2;

        Console.WriteLine("Prediction: " + prediction + " Expected: " + expected + " Error: " + _error);
        Console.WriteLine("output Activation derivative: " + outputActivationDerivative);

        Backpropagation(outputActivationDerivative, prediction);
    }

    private void Backpropagation(double outputActivationDerivative, double prediction)
    {
        for (int i = _network.Layers.Length - 1; i > 0; i--)
        {
            double gradient = -2 * _error * outputActivationDerivative;

            Console.WriteLine("Output Gradient: " + gradient);

            for (int j = 0; j < _network.Layers[j].Nodes.Length; j++)
            {
                for (int w = 0; w < _network.Layers[j].Nodes[j].Weights.Length; w++)
                {
                    var derivative = -2 * gradient * _network.Layers[j].Nodes[j].Weights[w];
                    _network.Layers[j].Nodes[j].Weights[w] += _learningRate * derivative * _network.Layers[j].Nodes[j].Value;
                }
            }
        }
    }

    private void Print(double[] inputs)
    {
        Console.WriteLine("############################################");
        for (int i = 0; i < inputs.Length; i++)
            Console.Write($" {inputs[i]}");
        Console.WriteLine(" ");
    }
}