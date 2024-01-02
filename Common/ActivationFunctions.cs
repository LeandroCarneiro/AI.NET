public static class ActivationFunctions
{
    public static double[] Sigmoid(double[] x, double euler = 2.71)
    {
        double[] result = new double[x.Length];

        for (int j = 0; j < x.Length; j++)
            result[j] = 1.0 / (1.0 + Math.Exp(-x[j]));

        return result;
    }
}