class TestException
{
    // 1 2 4 5
    public static void OrderOfFinallyExecution()
    {
        Console.WriteLine("1");
        _OrderOfFinallyExecution();
        Console.WriteLine("5");
    }
    public static void _OrderOfFinallyExecution()
    {
        try
        {
            Console.WriteLine("2");
            return;
#pragma warning disable CS0162 // Unreachable code detected
            Console.WriteLine("3");
#pragma warning restore CS0162 // Unreachable code detected
        }
        finally
        {
            Console.WriteLine("4");
        }
    }
}

