using System.ComponentModel.DataAnnotations;
using System.Dynamic;

class Input
{
    static public string GetString(Predicate<string?> Validator, string prompt = "Nhap mot string: ")
    {
        return Get(prompt, Validator, (str) => str);
    }

    static public int GetInt32(Predicate<string?> Validator, string prompt = "Nhap mot so nguyen 32 bit: ")
    {
        return Get(prompt, Validator, Int32.Parse);
    }

    static public bool GetBool(Predicate<string?> Validator, string prompt = "Nhap 'true' hoac 'false': ")
    {
        return Get(prompt, Validator, bool.Parse);
    }

    static public double GetDouble(Predicate<string?> Validator, string prompt = "Nhap mot so thap phan: ")
    {
        return Get(prompt, Validator, double.Parse);
    }
    static public DateTime GetDateTime(Predicate<string?> Validator, string prompt = "Nhap ngay thang nam DD/MM/YYYY: ")
    {
        return Get(prompt, Validator, DateTimeParser);
    }

    static public List<int> GetListInt(int count)
    {
        List<int> result = [];
        for (int i = 0; i < count; ++i)
        {
            result.Add(Get("Nhap mot so nguyen: ", ExerciseInt.Validator, Int32.Parse));
        }
        return result;
    }


    /// <summary>
    /// True if s is empty (for default choice) or contains either 'y', 'Y', 'n', 'N'
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    static public bool YesNoValidator(string? s)
    {
        return s != null &&
                (s == "" ||
                 s.Equals("n", StringComparison.CurrentCultureIgnoreCase) ||
                 s.Equals("y", StringComparison.CurrentCultureIgnoreCase));
    }

    static private DateTime DateTimeParser(string s)
    {
        return DateTime.ParseExact(s, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
    }

    // Validator dùng để lọc dữ liệu đầu vào bị sai
    // transformer dùng để biến đổi string input thành dữ liệu đầu ra
    static public T Get<T>(string prompt, Predicate<string?> Validator, Func<string, T> transformer)
    {
        while (true)
        {
            try
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (input != null && Validator(input))
                {
                    return transformer(input);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    public static bool PredicateTrue(string? _)
    {
        return true;
    }
    public static bool PredicateFalse(string? _)
    {
        return false;
    }
}