using System.Net.WebSockets;
using static System.Net.Mime.MediaTypeNames;


public class ExerciseTemplate
{


    public static bool TestMore()
    {
        var moreRecord = Input.GetString(Input.YesNoValidator, "Kiem tra tiep? (Y/n): ");
        return moreRecord.ToLower() != "n";
    }

    public static void AutomatedTest()
    {
        Console.WriteLine("TEST");
        Console.WriteLine();

    }

    public static bool Validator(string? _)
    {
        return true;
    }
}
