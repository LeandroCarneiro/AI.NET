


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
            Nodes[i] = new Node(0);
    }

    public abstract double[] ActivationFunction(double[] inputs);
    public abstract double[] SumUp(double[] inputs);

    public void UpdateNodes(double[] inputs)
    {
        for (int i = 0; i < Nodes.Length; i++)
            Nodes[i].Value = inputs[i];
    }

    protected double[,] GetMatrix()
    {
        var matrix = new double[Nodes.Length, Nodes[0].Weights.Length];

        for (int i = 0; i < Nodes.Length; i++)
        {
            for (int j = 0; j < Nodes[i].Weights.Length; j++)
                matrix[i, j] = Nodes[i].Weights[j];
        }

        return matrix;
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

    public override double[] SumUp(double[] inputs)
    {
        UpdateNodes(inputs);
        var matrixW = GetMatrix();
        double[,] matrixI = Utils.ConvertToMatrix(inputs, 1, inputs.Length);

        var result = Utils.MultiplyMatrix(matrixI, matrixW).Cast<double>().ToArray();

        return result.ToArray();
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
        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i] = Math.Tanh(inputs[i]); // Activation function (Tanh)
        }
        return inputs;
    }

    public override double[] SumUp(double[] inputs)
    {
        UpdateNodes(inputs);
        var result = new double[1] { inputs.Sum() };

        return (result);
    }
}