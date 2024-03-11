using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1.PrimitiveTests
{
    public class ExerciseBool
    {
        public static void AutomatedTest()
        {
            Console.WriteLine("BOOL AUTOMATED TEST");
            Input.GetBool(Validator);
            Console.WriteLine("Chuoi hop le");
            Console.WriteLine();
        }

        public static bool Validator(string? b)
        {
            if (b == null)
            {
                Console.WriteLine("Chuoi bi null.");
                return false;
            }

            var isBool = b.Equals(b, StringComparison.CurrentCultureIgnoreCase) && bool.TryParse(b, out _);
            if (!isBool)
            {
                Console.WriteLine("Khong phai chuoi bool");
            }
            return isBool;
        }
    }
}