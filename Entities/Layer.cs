


public abstract class LayerBase
{
    public Node[] Nodes { get; set; }

    public LayerBase()
    {
    }

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
    public abstract double ActivationFunctionDerivative(double input);

    public virtual double[] SumUp(double[] inputs)
    {
        var matrixW = GetMatrix();
        double[,] matrixI = Utils.ConvertToMatrix(inputs, 1, inputs.Length);

        var result = Utils.MultiplyMatrix(matrixI, matrixW).Cast<double>();

        return result.ToArray();
    }

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

    protected void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],4}"); // Adjust the width as needed
            }
            Console.WriteLine();
        }
    }
}

public class Layer : LayerBase
{
    public Layer(int quantity) : base(quantity)
    {
    }

    public Layer(int quantity, int bias) : base(quantity)
    {
        this.Nodes[quantity - 1] = new Node(bias, true);
    }

    public override double[] ActivationFunction(double[] inputs)
    {
        return ActivationFunctions.Sigmoid(inputs);
    }

    public override double ActivationFunctionDerivative(double input)
    {
        return input * (1 - input);
    }
}
public class InputLayer : LayerBase
{
    public InputLayer(int quantity)
    {
        Nodes = new Node[quantity];
        for (int i = 0; i < quantity; i++)
            Nodes[i] = new Node(0);
    }

    public override double[] ActivationFunction(double[] inputs)
    {
        return inputs;//bias;
    }

    public override double ActivationFunctionDerivative(double input)
    {
        return 1;
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
        return inputs;//bias;
    }

    public override double[] SumUp(double[] inputs)
    {
        return inputs;
    }

    public override double ActivationFunctionDerivative(double input)
    {
        return 1;
    }
}