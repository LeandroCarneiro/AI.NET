public class PerceptronFlow : BaseFlow
{
    public override void Execute()
    {
        Perceptron perceptron = new Perceptron(5, 0.6M);

        decimal[][] trainingData = new decimal[][] {
            new decimal[] {0, 1, 0, 0, 0},
            new decimal[] {0, 0, 1, 0, 1},
            new decimal[] {1, 0, 0, 1, 0},
            new decimal[] {1, 1, 1, 0, 0},
            new decimal[] {1, 1, 1, 1, 1},
            new decimal[] {1, 0, 1, 1, 0},
            new decimal[] {1, 1, 1, 1, 0},
            new decimal[] {1, 1, 1, 0, 0},
            new decimal[] {1, 1, 0, 1, 0},
            new decimal[] {1, 1, 1, 1, 0},
        };

        // Define the labels for the AND operation
        int[] labels = new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };


        for (int epoch = 0; epoch < 200; epoch++)
        {
            for (int i = 0; i < trainingData.Length; i++)
            {
                perceptron.Train(trainingData[i], labels[i]);
            }
        }

        decimal[][] trainingData2 = new decimal[][] {
                        new decimal[] {0, 0, 0, 0, 0},
                        new decimal[] {0, 1, 1, 0, 0},
                        new decimal[] {1, 1, 1, 1, 1},
                        new decimal[] {1, 0, 1, 0, 0},
                        new decimal[] {1, 0, 1, 0, 0},
                        new decimal[] {0, 0, 0, 0, 1},
                        new decimal[] {1, 0, 1, 0, 1},
                        new decimal[] {1, 1, 1, 1, 1},
                        new decimal[] {1, 1, 1, 0, 0}
                    };

        // Teste do Perceptron treinado
        foreach (decimal[] input in trainingData2)
        {
            int prediction = perceptron.Predict(input);
            Console.WriteLine($"Entrada: [{input[0]}, {input[1]}, {input[2]}, {input[3]}, {input[4]}] -> Saída: {prediction}");
        }
    }
}