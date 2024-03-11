using System.Net.NetworkInformation;
using static System.Net.Mime.MediaTypeNames;

public class ExerciseString
{
    public static void AutomatedTest()
    {

        Console.WriteLine("STRING AUTOMATED TEST");
        Console.WriteLine();


        Console.WriteLine("1.1: Input mot chuoi: ");
        Console.WriteLine($"Ket qua: '{Input.GetString(Validator)}'");

        Console.WriteLine("1.2: Bo ky tu trang o dau va cuoi");
        Console.WriteLine($"Ket qua: '{Input.GetString(Validator).Trim()}'");

        Console.WriteLine("1.3: Bo het ky tu trang");
        Console.WriteLine($"Ket qua: '{RemoveAllWhites(Input.GetString(Validator))}'");

        Console.WriteLine("1.4: Capitalize cac chu cai sau ki tu Space");
        Console.WriteLine($"Ket qua: '{WordsCapitalized(Input.GetString(Validator))}'");

        Console.WriteLine("1.5: Dem so ky tu space");
        Console.WriteLine($"Co [{CountSpaces(Input.GetString(Validator))}] ki tu space");

        Console.WriteLine("1.6: Dem so ky tu khong phai space");
        Console.WriteLine($"Co [{CountNonSpaces(Input.GetString(Validator))}] ki tu khac space");

        Console.WriteLine("1.7: So sanh 2 chuoi.");
        while (true)
        {
            var input1 = Input.GetString(Validator);
            var input2 = Input.GetString(Validator);
            Console.WriteLine($"Chuoi [{input1}] {(input1 == input2 ? "giong" : "khac")} chuoi [{input2}]");

            if (!ExerciseTemplate.TestMore())
            {
                break;
            }
        }

        Console.WriteLine("1.8: So sanh hai chuoi, khong phan biet hoa thuong.");
        while (true)
        {
            var input1 = Input.GetString(Validator);
            var input2 = Input.GetString(Validator);
            var equal = input1.ToLower() == input2.ToLower();
            Console.WriteLine($"Chuoi [{input1}] {(equal ? "giong" : "khac")} chuoi [{input2}]");

            if (!ExerciseTemplate.TestMore())
            {
                break;
            }
        }

        Console.WriteLine("1.9: Thay the 'ABC' thanh 'DEF'. Co phan biet hoa, thuong.");
        Console.WriteLine($"Ket qua: {Input.GetString(Validator).Replace("ABC", "DEF")}");


        Console.WriteLine("1.10: Hien thi chuoi: Kinh chao ong [input]. Chuc ngon mieng.");
        Console.WriteLine($"Ket qua: Kinh chao ong {WordsCapitalized(Input.GetString(Validator).Trim())}. Chuc ngon mieng.");



        Console.WriteLine("1.11: Dao nguoc cac ky tu cua chuoi.");
        Console.WriteLine($"Ket qua: '{Reverse(Input.GetString(Validator))}'");


        Console.WriteLine("1.12: Bo ky tu trang o DAU chuoi, lay X ky tu DAU cua chuoi");
        var x = Input.GetInt32(IntValidator, "Nhap so nguyen X:");
        var str = Input.GetString(Validator);
        Console.WriteLine($"Ket qua: '{FirstCount(str.TrimStart(), x)}'");

        Console.WriteLine("1.13: Bo ky tu trang o DAU VA CUOI chuoi, lay X ky tu DAU cua chuoi");
        x = Input.GetInt32(IntValidator, "Nhap so nguyen X:");
        str = Input.GetString(Validator);
        Console.WriteLine($"Ket qua: '{FirstCount(str.Trim(), x)}'");

        Console.WriteLine("1.14: Bo ky tu trang o DAU VA CUOI chuoi, lay X ky tu CUOI cua chuoi");
        x = Input.GetInt32(IntValidator, "Nhap so nguyen X:");
        str = Input.GetString(Validator);
        Console.WriteLine($"Ket qua: '{LastCount(str.Trim(), x)}'");
    }

    private static bool IntValidator(string? s)
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

        if (result < 0)
        {
            Console.WriteLine("So nho hon 0");
            return false;
        }
        return true;
    }

    private static string FirstCount(string s, int count)
    {
        return s[..Math.Min(count, s.Length)];
    }

    private static string LastCount(string s, int count)
    {
        return s.Substring(Math.Max(0, s.Length - count), count);
    }

    private static string Reverse(string testString)
    {
        return string.Join("", testString.Reverse());
    }

    private static int CountNonSpaces(string testString)
    {
        return testString.Length - CountSpaces(testString);
    }


    /// <summary>
    /// 1.1. Trả về false và thông báo nếu chuỗi null, rỗng, hoặc toàn trắng. 
    /// True với các trường hợp còn lại.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool Validator(string? str)
    {
        if (str == null)
        {
            Console.WriteLine("Chuoi bi null");
            return false;
        }
        if (str.Length == 0)
        {
            Console.WriteLine("Chuoi rong");
            return false;
        }

        if (str.Trim().Length == 0)
        {
            Console.WriteLine("Chuoi Space");
            return false;
        }
        return true;
    }


    private static string RemoveAllWhites(string str)
    {
        var result = "";
        foreach (char c in str)
        {
            if (!char.IsWhiteSpace(c))
            {
                result += c;
            }
        }
        return result;
    }




    public static string WordsCapitalized(string str)
    {
        var result = "";

        for (int i = 0; i < str!.Length; i++)
        {
            if (i == 0 || (str[i - 1] == ' '))
            {
                result += str[i].ToString().ToUpper()[0];
            }
            else
            {
                result += str[i];
            }
        }
        return result;
    }

    public static int CountSpaces(string str)
    {
        var count = 0;
        foreach (char c in str)
        {
            if (c == ' ')
            {
                count += 1;
            }
        }
        return count;
    }


}
