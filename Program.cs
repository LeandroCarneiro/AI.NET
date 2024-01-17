public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("0 - Perceptron");
        Console.WriteLine("1 - Perceptron Backpropagation");
        var option = "1";//Console.ReadLine();

        BaseFlow flow;

        if (option == "0")
            flow = new PerceptronFlow();
        else
            flow = new PerceptronBackpropagationFlow();

        flow.Execute();
    }
}