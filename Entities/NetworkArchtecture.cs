public class NetworkArchtecture
{
    public LayerBase[] Layers { get; set; }

    public NetworkArchtecture(LayerBase[] layers)
    {
        Layers = layers;
        Setup();
    }

    public double[,] Setup()
    {
        Validatate();
        int maxLines = Layers[0].Nodes.Length;
        int maxCol = Layers[1].Nodes.Length * maxLines;

        for (int i = 0; i < Layers.Length - 1; i++)
        {
            foreach (var item in Layers[i].Nodes)
            {
                var lenNext = Layers[i + 1].Nodes.Length;
                var lenCurrent = Layers[i].Nodes.Length;

                item.GenerateWeights(lenNext);

                if (lenNext > maxLines)
                    maxLines = lenNext;

                if (lenCurrent * lenNext > maxCol)
                    maxCol = lenCurrent * lenNext;
            }
        }
        return CreateWMatrix(maxLines, maxCol);
    }

    private double[,] CreateWMatrix(int maxLines, int maxCol)
    {
        var result = new double[maxLines, maxCol];
        for (int i = 0; i < Layers.Length - 1; i++)
        {
            result.SetValue(Layers[i].Nodes[i].Weights, i);
        }

        return result;
    }

    private void Validatate()
    {
        if (Layers == null || !Layers.Any())
            throw new Exception("Add at least 3 layers including input and output");

        if (Layers.LastOrDefault() is not OutputLayer)
            throw new Exception("The last layer of your neural network must be OutputLayer type");
    }
}