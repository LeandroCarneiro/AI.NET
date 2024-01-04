public static class Utils
{
    public static decimal[] SumArrays(decimal[] array1, decimal[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Input arrays must have the same length.");

        return array1.Zip(array2, (x, y) => x + y).ToArray();
    }

    public static decimal MultiplyArrays(decimal[] array1, decimal[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Input arrays must have the same length.");

        var result = array1.Zip(array2, (x, y) => x * y).ToArray();
        return result.Sum();
    }

    public static double[,] MultiplyMatrix(double[,] matrixA, double[,] matrixB)
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        int rowsB = matrixB.GetLength(0);
        int colsB = matrixB.GetLength(1);

        if (colsA != rowsB)
            throw new ArgumentException("Matrix dimensions are not suitable for multiplication.");

        double[,] resultMatrix = new double[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                double sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += matrixA[i, k] * matrixB[k, j];
                }
                resultMatrix[i, j] = sum;
            }
        }

        return resultMatrix;
    }

    public static double[,] ConvertToMatrix(double[] flat, int m, int n)
    {
        if (flat.Length != m * n)
            throw new ArgumentException("Invalid length");

        double[,] ret = new double[m, n];
        // BlockCopy uses byte lengths: a double is 8 bytes
        Buffer.BlockCopy(flat, 0, ret, 0, flat.Length * sizeof(double));
        return ret;
    }

    public static double[][] ToJagged(double[] array, int inputsQuantity, int outputsQuantity)
    {
        double[][] result = new double[outputsQuantity][];
        int index = 0;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < inputsQuantity; j++)
                result[i][j] = array[index++];
        }

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

    public static T[,] InitializeMatrix<T>(int rows, int cols, T minValue, T maxValue) where T : IConvertible
    {
        T[,] matrix = new T[rows, cols];
        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                matrix[i, j] = (T)Convert.ChangeType(random.NextDouble() * (Convert.ToDouble(maxValue) - Convert.ToDouble(minValue)) + Convert.ToDouble(minValue), typeof(T));
        }

        return matrix;
    }

    public static T[] GetColumn<T>(T[,] matrix, int columnNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(0))
                .Select(x => matrix[x, columnNumber])
                .ToArray();
    }

    public static T[] GetRow<T>(T[,] matrix, int rowNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(1))
                .Select(x => matrix[rowNumber, x])
                .ToArray();
    }
}