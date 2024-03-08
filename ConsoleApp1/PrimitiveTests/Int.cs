using static System.Net.Mime.MediaTypeNames;

public class ExerciseInt
{
    public static void automatedTest()
    {
        Console.WriteLine("INT AUTOMATED TEST");
        Console.WriteLine();

        int x;
        int y;

        Console.WriteLine("1.1: Input: Mot so 32 bit lon hon 0.");
        x = Input.GetInt32(positiveValidator);
        Console.WriteLine($"Ket qua: {x}. So {(x % 2 == 0? "chan" : "le")}");


        Console.WriteLine("1.2: |x|");
        x = Input.GetInt32(validator);
        Console.WriteLine($"|{x}| = {Math.Abs(x)}.");

        Console.WriteLine("1.3: 2^x");
        x = Input.GetInt32(validator);
        Console.WriteLine($"2^{x}: {Math.Pow(2, x)}.");


        Console.WriteLine("1.4: x / y");
        x = Input.GetInt32(validator, "Nhap X: ");
        y = Input.GetInt32(validator, "Nhap Y: ");
        Console.WriteLine($"{x}/{y} = {x / y} du {x % y}");

        Console.WriteLine("1.5: Test so nguyen to.");
        while (true)
        {
            x = Input.GetInt32(validator);
            var truePrime = isPrime(x);
            if (truePrime)
            {
                Console.WriteLine($"{x} la so nguyen to.");
            }
            else
            {
                Console.WriteLine($"{x} khong phai so nguyen to.");
            }
            if (!ExerciseTemplate.testMore())
            {
                break;
            }
        }


        Console.WriteLine("1.6: Validate chuoi so:");
        Input.GetInt32(validator);
        Console.WriteLine("Chuoi so.");
    }

    public static bool isPrime(int x)
    {
        if (x == 1) return true;

        for (int i = 2; i < Math.Ceiling(Math.Sqrt(x)); i++)
        {
            if (x % i == 0) return false;
        }

        return true;
    }

    public static bool validator(string? s)
    {
        if (s == null)
        {
            Console.WriteLine("Chuoi so bi null");
            return false;
        }
        int result;
        if (!Int32.TryParse(s, out result))
        {
            Console.WriteLine("Chuoi so khong phai 32 bit");
            return false;
        }

        return true;
    }

    public static bool nonZeroValidator(string? s)
    {
        if (s == null)
        {
            Console.WriteLine("Chuoi so bi null");
            return false;
        }
        int result;
        if (!Int32.TryParse(s, out result))
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

    public static bool positiveValidator(string? s)
    {
        if (s == null)
        {
            Console.WriteLine("Chuoi so bi null");
            return false;
        }
        int result;
        if (!Int32.TryParse(s, out result))
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
