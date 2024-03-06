using static System.Net.Mime.MediaTypeNames;


public class ExerciseTemplate
{
    public static bool testMore()
    {
        var moreRecord = Input.GetString(Input.yesNoValidator, "Kiem tra tiep? (Y/n): ");
        return moreRecord.ToLower() != "n";
    }

    public static void automatedTest()
    {
        Console.WriteLine(" TEST");
        Console.WriteLine();
    }

    public static bool validator(string? b) {
        return true;
    }
}
