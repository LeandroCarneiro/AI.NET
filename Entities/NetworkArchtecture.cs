public class NetworkArchtecture
{
    public LayerBase[] Layers { get; set; }

    public NetworkArchtecture(LayerBase[] layers)
    {
        Layers = layers;
        Setup();
    }

    public void Setup()
    {
        Validatate();

        for (int i = 0; i < Layers.Length - 1; i++)
        {
            var lenNext = Layers[i + 1].Nodes.Length;
            for (int j = 0; j < Layers[i].Nodes.Length; j++)
                Layers[i].Nodes[j].GenerateWeights(lenNext);
        }
    }

    private void Validatate()
    {
        if (Layers == null || !Layers.Any())
            throw new Exception("Add at least 3 layers including input and output");

        if (Layers.FirstOrDefault() is not InputLayer)
            throw new Exception("The first layer of your neural network must be InputLayer type");

        if (Layers.LastOrDefault() is not OutputLayer)
            throw new Exception("The last layer of your neural network must be OutputLayer type");
    }
}