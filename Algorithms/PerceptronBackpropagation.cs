

public class PerceptronBackpropagation
{
    private readonly double _learningRate;
    private NetworkArchtecture _network;
    public double _error = 0;
    private double _errorMSE = 0;
    private double _cost = 0;

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
            item.UpdateNodes(output);
            var result = item.ActivationFunction(output);
            output = item.SumUp(result);
        }

        return output;
    }

    internal void Train(double[] inputs, int expected)
    {
        // Print(inputs);
        var prediction = FeedForward(inputs).Sum();
        _error = expected - prediction;

        // Console.WriteLine("Prediction: " + prediction + " Expected: " + expected + " ERROR: " + _error);

        Backpropagation();
    }

    private void Backpropagation()
    {
        // A derivada do MSE é simplesmente o erro vezes -2, dividido pelo número de exemplos
        double delta = _error;

        for (int layer = _network.Layers.Length - 2; layer > 0; layer--)
        {
            for (int node = 0; node < _network.Layers[layer].Nodes.Length; node++)
            {
                for (int i = 0; i < _network.Layers[layer].Nodes[node].Weights.Length; i++)
                {
                    _network.Layers[layer].Nodes[node].Weights[i] -= _learningRate * delta * _network.Layers[layer].Nodes[node].Value;
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