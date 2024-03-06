using static System.Net.Mime.MediaTypeNames;

public class ExerciseBool
{
    public static void automatedTest()
    {
        Console.WriteLine("BOOL AUTOMATED TEST");
        Input.GetBool(validator);
        Console.WriteLine("Chuoi hop le");
        Console.WriteLine();
    }

    public static bool validator(string? b) {
        if (b == null)
        {
            Console.WriteLine("Chuoi bi null.");
            return false;
        }

        var isBool = b.ToLower() == b && bool.TryParse(b, out _);
        if (!isBool)
        {
            Console.WriteLine("Khong phai chuoi bool");
        }
        return isBool;
    }
}
