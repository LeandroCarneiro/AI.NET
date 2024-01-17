public class PerceptronBackpropagationFlow : BaseFlow
{
    public override void Execute()
    {
        var layer1 = new InputLayer(2);
        var layer2 = new Layer(3);
        var layer3 = new OutputLayer(1);

        var archtecture = new NetworkArchtecture(new LayerBase[] { layer1, layer2, layer3 });

        PerceptronBackpropagation perceptron = new PerceptronBackpropagation(archtecture, 0.02);

        double[][] trainingData = new double[][]
        {
            new double[] { 2, 3 },
            new double[] { 2, 4 },
            new double[] { 1, 3 },
            new double[] { 3, 4 },
            new double[] { 1, 2 },
            new double[] { 2, 6 },
            new double[] { 3, 2 },
            new double[] { 4, 5 },
            new double[] { 1, 5 },
        };

        int[] labels = new int[] { 5, 6, 4, 7, 3, 8, 5, 9, 6 };

        for (int epoch = 0; epoch < 2000; epoch++)
        {
            for (int i = 0; i < trainingData.Length; i++)
                perceptron.Train(trainingData[i], labels[i]);

            Console.WriteLine("Epocha: " + epoch + " Error: " + perceptron._error);
        }

        for (int i = 0; i < trainingData.Length; i++)
        {
            double[] output = perceptron.FeedForward(trainingData[i]);
            Console.WriteLine($"Input: [{trainingData[i][0]}, {trainingData[i][1]}], Output: {output[0]}");
        }
    }
}