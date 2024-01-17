public static class ActivationFunctions
{
    public static double[] Sigmoid(double[] x, double euler = 2.71)
    {
        double[] result = new double[x.Length];

        for (int j = 0; j < x.Length; j++)
            result[j] = 1 / (1 + Math.Pow(euler, x[j]));

        return result;
    }

    public static double[] Linear(double[] inputs)
    {
        var result = new double[1] { inputs.Sum() };
        return result;
    }

    public static double[] Tanh(double[] inputs)
    {
        double[] result = new double[inputs.Length];

        for (int j = 0; j < inputs.Length; j++)
            result[j] = Math.Tanh(inputs[j]);

        return result;
    }
}