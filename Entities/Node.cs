
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
        throw new NotImplementedException();
    }
}