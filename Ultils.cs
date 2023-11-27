public static class Utils
{
    public static decimal[] SumArrays(decimal[] array1, decimal[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Input arrays must have the same length.");

        return array1.Zip(array2, (x, y) => x + y).ToArray();
    }

    public static decimal[] MultiplyArrays(decimal[] array1, decimal[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Input arrays must have the same length.");

        var result = array1.Zip(array2, (x, y) => x * y).ToArray();
        return result;
    }


    public static double[] InitializeArray(int length, int minValue, int maxValue)
    {
        Random random = new Random();

        double[] randomArray = Enumerable.Range(0, length)
            .Select(_ => random.NextDouble() * (maxValue - minValue) + minValue)
            .ToArray();

        return randomArray;
    }

    public static T InitializeDouble<T>(int minValue, int maxValue) where T : IConvertible
    {
        Random random = new Random();
        return (T)Convert.ChangeType(random.NextDouble() * (maxValue - minValue) + minValue, typeof(T));
    }

    public static T[] InitializeArray<T>(int length, T minValue, T maxValue) where T : IConvertible
    {
        Random random = new Random();

        T[] randomArray = Enumerable.Range(0, length)
            .Select(_ => (T)Convert.ChangeType(random.NextDouble() * (Convert.ToDouble(maxValue) - Convert.ToDouble(minValue)) + Convert.ToDouble(minValue), typeof(T)))
            .ToArray();

        return randomArray;
    }
}