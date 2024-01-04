
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
        return null;
    }

    internal void Train(double[] inputs, int v)
    {
        do
        {
            var prediction = Predict(inputs);
        } while (_error != 0);
    }

    public int Predict(double[] inputs)
    {
        foreach (var item in _network.Layers)
        {
            var sum = item.SumUp(inputs);
        }

        return 0;
    }

    private double[] SumUp(double[] inputs, double[][] weights)
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            Console.WriteLine($"{inputs[i]}");
        }
        for (int i = 0; i < inputs.Length; i++)
        {
            Console.WriteLine($"{weights[i]}");
        }

        return null;
    }
}