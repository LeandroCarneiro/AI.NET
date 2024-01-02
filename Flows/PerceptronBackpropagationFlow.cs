public class PerceptronBackpropagationFlow : BaseFlow
{
    public override void Execute()
    {
        var layer1 = new Layer(3);
        var layer2 = new Layer(2);
        var layer3 = new OutputLayer(1);

        var archtecture = new NetworkArchtecture(new LayerBase[] { layer1, layer2, layer3 });

        PerceptronBackpropagation perceptron = new PerceptronBackpropagation(archtecture, 0.6);

        double[][] trainingData = new double[][]
        {
            new double[] { 1, 1, 2, 3 },
            new double[] { 1, 3, 4, 7 },
            new double[] { 3, 3, 6, 9 },
            new double[] { 2, 1, 3, 4 },
            new double[] { 12, 1, 13, 14 },
            new double[] { 50, 60, 110, 170 },
        };

        int[] labels = new int[] { 5, 11, 15, 7, 27, 280 };

        for (int epoch = 0; epoch < 200; epoch++)
        {
            for (int i = 0; i < trainingData.Length; i++)
                perceptron.Train(trainingData[i], labels[i]);
        }
    }
}