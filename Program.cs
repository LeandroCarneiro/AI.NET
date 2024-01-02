public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("0 - Perceptron");
        Console.WriteLine("1 - Perceptron Backpropagation");
        var option = Console.ReadLine();

        if (option == "0")
            PerceptronFlow.Flow();
        else
            PerceptronBackpropagationFlow.Flow();
    }
}