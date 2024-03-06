using static System.Net.Mime.MediaTypeNames;

public class ExerciseDictionary
{
    public static void automatedTest()
    {
        Console.WriteLine("Dictionary TEST");
        Console.WriteLine();

        bai11();
        bai12();
        bai13();
        bai14();
        bai15();
    }

    private static void bai11()
    {
        Console.WriteLine("1.1: Tao Dictionary voi 5 key-value bat ky:");
        Console.WriteLine(ToString(generateRandomDictionary(5)));
        Console.WriteLine();
    }

    private static void bai12()
    {
        Dictionary<int, string> dict;
        KeyValuePair<int, string> record;

        Console.WriteLine("1.2: Nhap 1 Dictionary, 1 ma SV va ten SV. CHECK sinh vien.");
        Console.WriteLine("Nhap Dictionary: ");
        dict = promptInputDictionary();
        Console.WriteLine($"Dictionary: {ToString(dict)}");

        while (true)
        {
            Console.WriteLine("Nhap ban ghi sinh vien: ");
            record = GetStudentRecord();
            if (!dict.ContainsKey(record.Key))
            {
                Console.WriteLine($"Khong co sinh vien co ma {record.Key}");
            }
            else
            {
                Console.WriteLine($"Sinh vien '{dict[record.Key]}'");

            }

            if (!ExerciseTemplate.testMore())
            {
                break;
            }
        }
        Console.WriteLine();

    }

    private static void bai13()
    {
        Dictionary<int, string> dict;
        KeyValuePair<int, string> record;

        Console.WriteLine("1.3: Nhap 1 Dictionary, 1 ma SV va ten SV. THEM sinh vien");
        Console.WriteLine("Nhap Dictionary: ");
        dict = promptInputDictionary();
        Console.WriteLine($"Dictionary: {ToString(dict)}");

        while (true)
        {
            Console.WriteLine("Nhap ban ghi sinh vien: ");
            record = GetStudentRecord();
            if (!dict.ContainsKey(record.Key))
            {
                dict[record.Key] = record.Value;
                Console.WriteLine($"Da them sinh vien co ma {record.Key}, ten '{record.Value}' vao Dictionary.");
            }
            else
            {
                Console.WriteLine($"Da co sinh vien co ma {record.Key} trong Dictionary.");
            }

            if (!ExerciseTemplate.testMore())
            {
                break;
            }
        }
        Console.WriteLine();
    }


    private static void bai14()
    {
        Dictionary<int, string> dict;
        KeyValuePair<int, string> record;

        Console.WriteLine("1.4: Nhap 1 Dictionary, 1 ma SV va ten SV. THEM va DOI TEN sinh vien");
        Console.WriteLine("Nhap Dictionary: ");
        dict = promptInputDictionary();
        Console.WriteLine($"Dictionary: {ToString(dict)}");

        while (true)
        {
            Console.WriteLine("Nhap ban ghi sinh vien: ");
            record = GetStudentRecord();
            if (!dict.ContainsKey(record.Key))
            {
                dict[record.Key] = record.Value;
                Console.WriteLine($"Da them sinh vien co ma {record.Key}, ten '{record.Value}' vao Dictionary.");
            }
            else
            {
                var oldName = dict[record.Key];
                dict[record.Key] = record.Value;
                Console.WriteLine($"Da thay ten sinh vien co ma {record.Key} trong Dictionary tu '{oldName}' thanh '{dict[record.Key]}'.");
            }

            if (!ExerciseTemplate.testMore())
            {
                break;
            }
        }
        Console.WriteLine();
    }

    private static void bai15()
    {
        Dictionary<int, string> dict;
        KeyValuePair<int, string> record;

        Console.WriteLine("1.5: Nhap 1 Dictionary, 1 ma SV va ten SV. XOA sinh vien");
        Console.WriteLine("Nhap Dictionary: ");

        dict = promptInputDictionary();

        Console.WriteLine($"Dictionary: {ToString(dict)}");

        while (true)
        {
            Console.WriteLine("Nhap ban ghi sinh vien: ");
            record = GetStudentRecord();
            if (!dict.ContainsKey(record.Key))
            {
                Console.WriteLine($"Khong co sinh vien co ma {record.Key}.");
            }
            else
            {
                dict.Remove(record.Key);
                Console.WriteLine($"Da xoa sinh vien co ma {record.Key}.");
            }

            if (!ExerciseTemplate.testMore())
            {
                break;
            }
        }
        Console.WriteLine();
    }

    public static Dictionary<int, string> promptInputDictionary()
    {
        Dictionary<int, string> result = new Dictionary<int, string> { };
        while (true)
        {
            var moreRecord = Input.GetString(Input.yesNoValidator, "Them ban ghi moi? (Y/n): ");
            if (moreRecord.ToLower() == "n")
            {
                break;
            }
            //Console.WriteLine($"moreRecord: '{moreRecord}'");

            var record = GetStudentRecord();
            if (result.ContainsKey(record.Key))
            {
                Console.WriteLine($"Ghi de ban ghi sinh vien {record.Key}");
            }
            result[record.Key] = record.Value;
        }
        return result;
    }


    static public KeyValuePair<int, string> GetStudentRecord()
    {
        KeyValuePair<int, string> result;
        result = new KeyValuePair<int, string>(
            Input.GetInt32(ExerciseInt.validator, "Nhap ma so sinh vien: "),
            Input.GetString(ExerciseString.validator, "Nhap ten sinh vien: "));
        return result;
    }


    public static Dictionary<int, string> generateRandomDictionary(int count)
    {
        List<string> firstName = ["Tran", "Nguyen", "Do", "Hoang"];
        List<string> middleName = ["Thi", "Van", "Minh", "Quoc"];
        List<string> lastName = ["Hong", "Duc", "Tuan", "Tu"];

        Dictionary<int, string> result = new Dictionary<int, string>{};
        var rand = new Random();
        while (result.Count < count)
        {
            result.Add(rand.Next(), 
                firstName[rand.Next(0, firstName.Count)] + " " +
                middleName[rand.Next(0, middleName.Count)] + " " +
                lastName[rand.Next(0, lastName.Count)]
                );
        }

        return result;
    }

    public static string ToString(Dictionary<int, string> dict)
    {
        return $"{{{(String.Join(", ", dict.ToList().ConvertAll(keyValue => $"{keyValue.Key}: {keyValue.Value}")))}}}";
    }

    public static bool validator(string? b) {
        return true;
    }
}
