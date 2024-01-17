public class Node
{
    public double Value { get; set; }
    public bool IsBias { get; set; }
    public double[] Weights { get; set; }

    public Node(double value = 0, bool isBias = false)
    {
        IsBias = isBias;
        Value = value;
    }

    public void GenerateWeights(int length)
    {
        Weights = Utils.InitializeArray(length, -1, 1);
    }

    public void PrintNode()
    {
        Console.WriteLine($"\n\nNode Information:");
        Console.WriteLine($"Value: {Value}");
        Console.WriteLine($"Is Bias: {IsBias}");
        Console.Write("Weights: [");

        for (int i = 0; i < Weights.Length; i++)
        {
            Console.Write($"{Weights[i]}");
            if (i < Weights.Length - 1)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine("]\n");
    }
}