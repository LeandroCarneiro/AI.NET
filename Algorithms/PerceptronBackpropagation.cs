public class PerceptronBackpropagation
{
    private readonly double _learningRate;
    private NetworkArchtecture _network;
    public PerceptronBackpropagation(NetworkArchtecture archtecture, double learningRate)
    {
        _network = archtecture;
        _learningRate = learningRate;
    }

    public void Intialize()
    {
    }

    public double[] FeedForward(double[] inputs)
    {
        return null;
    }

    internal void Train(double[] inputs, int v)
    {
        FeedForward(inputs);
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