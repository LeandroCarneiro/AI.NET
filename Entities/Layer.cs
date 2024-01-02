public abstract class LayerBase
{
    public Node[] Nodes { get; set; }

    public LayerBase(Node[] nodes)
    {
        Nodes = nodes;
    }

    public LayerBase(int quantity)
    {
        Nodes = new Node[quantity];
        for (int i = 0; i < quantity; i++)
            Nodes.Append(new Node(0));
    }


    public abstract double[] ActivationFunction(double[] inputs);
    public double SumUp(double[] inputs)
    {
        return inputs.Sum();
    }
}

public class Layer : LayerBase
{
    public Layer(Node[] nodes) : base(nodes)
    {
    }

    public Layer(int quantity) : base(quantity)
    {
    }

    public override double[] ActivationFunction(double[] inputs)
    {
        return ActivationFunctions.Sigmoid(inputs);
    }
}

public class OutputLayer : LayerBase
{
    public OutputLayer(Node[] nodes) : base(nodes)
    {
    }

    public OutputLayer(int quantity) : base(quantity)
    {
    }

    public override double[] ActivationFunction(double[] inputs)
    {
        return inputs;
    }
}