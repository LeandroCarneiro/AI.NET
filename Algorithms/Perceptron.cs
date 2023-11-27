public class Perceptron
{
    private decimal[] Weights { get; set; }
    private static int BIAS => 1;
    private decimal BiasWeight;
    private static decimal RATE;
    private decimal _error;

    public Perceptron(int quantity, decimal rate)
    {
        Weights = Utils.InitializeArray<decimal>(quantity, -1, 1);
        BiasWeight = Utils.InitializeDouble<decimal>(-1, 1);

        RATE = rate;
    }

    private decimal SumFunction(decimal[] inputs)
    {
        var result = Utils.MultiplyArrays(inputs, Weights);

        var sumResult = (result.Sum() / inputs.Length) + (BIAS * BiasWeight);

        return sumResult;
    }

    public int Predict(decimal[] inputs)
    {
        var sum = SumFunction(inputs);
        // Console.WriteLine("Sum: " + sum);
        return sum > 0 ? 1 : 0;
    }

    public void Train(decimal[] inputs, int target)
    {
        // Console.WriteLine("Inputs: " + string.Join(", ", inputs));
        do
        {
            var prediction = Predict(inputs);
            _error = target - prediction;

            for (int i = 0; i < Weights.Length; i++)
                Weights[i] += RATE * _error * inputs[i];

            BiasWeight += RATE * _error * BIAS;

            // Console.WriteLine("Prediction: " + prediction);
            // Console.WriteLine("Target: " + target);
            // Console.WriteLine("Error: " + _error);
        } while (_error != 0);
    }
}