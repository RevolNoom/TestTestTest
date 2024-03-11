using static System.Net.Mime.MediaTypeNames;

public class ExerciseInt
{
    public static void AutomatedTest()
    {
        Console.WriteLine("INT AUTOMATED TEST");
        Console.WriteLine();

        int x;
        int y;

        Console.WriteLine("1.1: Input: Mot so 32 bit lon hon 0.");
        x = Input.GetInt32(PositiveValidator);
        Console.WriteLine($"Ket qua: {x}. So {(x % 2 == 0 ? "chan" : "le")}");


        Console.WriteLine("1.2: |x|");
        x = Input.GetInt32(Validator);
        Console.WriteLine($"|{x}| = {Math.Abs(x)}.");

        Console.WriteLine("1.3: 2^x");
        x = Input.GetInt32(Validator);
        Console.WriteLine($"2^{x}: {Math.Pow(2, x)}.");


        Console.WriteLine("1.4: x / y");
        x = Input.GetInt32(Validator, "Nhap X: ");
        y = Input.GetInt32(Validator, "Nhap Y: ");
        Console.WriteLine($"{x}/{y} = {x / y} du {x % y}");

        Console.WriteLine("1.5: Test so nguyen to.");
        while (true)
        {
            x = Input.GetInt32(Validator);
            var truePrime = IsPrime(x);
            if (truePrime)
            {
                Console.WriteLine($"{x} la so nguyen to.");
            }
            else
            {
                Console.WriteLine($"{x} khong phai so nguyen to.");
            }
            if (!ExerciseTemplate.TestMore())
            {
                break;
            }
        }


        Console.WriteLine("1.6: Validate chuoi so:");
        Input.GetInt32(Validator);
        Console.WriteLine("Chuoi so.");
    }

    public static bool IsPrime(int x)
    {
        if (x == 1) return true;

        for (int i = 2; i < Math.Ceiling(Math.Sqrt(x)); i++)
        {
            if (x % i == 0) return false;
        }

        return true;
    }

    public static bool Validator(string? s)
    {
        if (s == null)
        {
            Console.WriteLine("Chuoi so bi null");
            return false;
        }

        if (!Int32.TryParse(s, out _))
        {
            Console.WriteLine("Chuoi so khong phai 32 bit");
            return false;
        }

        return true;
    }

    public static bool NonZeroValidator(string? s)
    {
        if (s == null)
        {
            Console.WriteLine("Chuoi so bi null");
            return false;
        }
        if (!Int32.TryParse(s, out int result))
        {
            Console.WriteLine("Chuoi so khong phai 32 bit");
            return false;
        }

        if (result == 0)
        {
            Console.WriteLine("So khong duoc bang 0");
            return false;
        }
        return true;
    }

    public static bool PositiveValidator(string? s)
    {
        if (s == null)
        {
            Console.WriteLine("Chuoi so bi null");
            return false;
        }
        if (!Int32.TryParse(s, out int result))
        {
            Console.WriteLine("Chuoi so khong phai 32 bit");
            return false;
        }

        if (result <= 0)
        {
            Console.WriteLine("So khong lon hon 0");
            return false;
        }
        return true;
    }
}
