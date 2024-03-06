using System.ComponentModel.DataAnnotations;
using System.Dynamic;

class Input
{
    static public string GetString(Predicate<string?> validator, string prompt = "Nhap mot string: ")
    {
        return Get(prompt, validator, (str) => str);
    }

    static public int GetInt32(Predicate<string?> validator, string prompt = "Nhap mot so nguyen 32 bit: ")
    {
        return Get(prompt, validator, Int32.Parse);
    }

    static public bool GetBool(Predicate<string?> validator, string prompt = "Nhap 'true' hoac 'false': ")
    {
        return Get(prompt, validator, bool.Parse);
    }

    static public double GetDouble(Predicate<string?> validator, string prompt = "Nhap mot so thap phan: ")
    {
        return Get(prompt, validator, double.Parse);
    }
    static public DateTime GetDateTime(Predicate<string?> validator, string prompt = "Nhap ngay thang nam DD/MM/YYYY: ")
    {
        return Get(prompt, validator, dateTimeParser);
    }

    static public List<int> GetListInt(int count)
    {
        List<int> result = [];
        for (int i = 0; i < count; ++i)
        {
            result.Add(Get("Nhap mot so nguyen: ", ExerciseInt.validator, Int32.Parse));
        }
        return result;
    }


    /// <summary>
    /// True if s is empty (for default choice) or contains either 'y', 'Y', 'n', 'N'
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    static public bool yesNoValidator(string? s)
    {
        return s != null && 
                (s == "" || 
                 s.ToLower() == "n" ||
                 s.ToLower() == "y");
    }

    static private DateTime dateTimeParser(string s)
    {
        return DateTime.ParseExact(s, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
    }

    // validator dùng để lọc dữ liệu đầu vào bị sai
    // transformer dùng để biến đổi string input thành dữ liệu đầu ra
    static public T Get<T>(string prompt, Predicate<string?> validator, Func<string, T> transformer)
    {
        while (true)
        {
            try
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (input != null && validator(input))
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

    public static bool predicateTrue(string? s)
    {
        return true;
    }
    public static bool predicateFalse(string? s)
    {
        return false;
    }
}