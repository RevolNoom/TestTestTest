class TestException
{
    // 1 2 4 5
    public static void orderOfFinallyExecution()
    {
        Console.WriteLine("1");
        _orderOfFinallyExecution();
        Console.WriteLine("5");
    }
    public static void _orderOfFinallyExecution()
    {
        try
        {
            Console.WriteLine("2");
            return;
            Console.WriteLine("3");
        }
        finally
        {
            Console.WriteLine("4");
        }
    }
}

