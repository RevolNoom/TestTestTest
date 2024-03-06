using System.Net.NetworkInformation;
using static System.Net.Mime.MediaTypeNames;

public class ExerciseString
{
    public static void automatedTest()
    {

        Console.WriteLine("STRING AUTOMATED TEST");
        Console.WriteLine();

        
        Console.WriteLine("1.1: Input mot chuoi: ");
        Console.WriteLine($"Ket qua: '{Input.GetString(validator)}'");

        Console.WriteLine("1.2: Bo ky tu trang o dau va cuoi");
        Console.WriteLine($"Ket qua: '{Input.GetString(validator).Trim()}'");

        Console.WriteLine("1.3: Bo het ky tu trang");
        Console.WriteLine($"Ket qua: '{removeAllWhites(Input.GetString(validator))}'");

        Console.WriteLine("1.4: Capitalize cac chu cai sau ki tu Space");
        Console.WriteLine($"Ket qua: '{wordsCapitalized(Input.GetString(validator))}'");

        Console.WriteLine("1.5: Dem so ky tu space");
        Console.WriteLine($"Co [{countSpaces(Input.GetString(validator))}] ki tu space");

        Console.WriteLine("1.6: Dem so ky tu khong phai space");
        Console.WriteLine($"Co [{countNonSpaces(Input.GetString(validator))}] ki tu khac space");

        Console.WriteLine("1.7: So sanh 2 chuoi. Neu giong nhau thi di tiep 1.8.");
        while (true)
        {
            var input1 = Input.GetString(validator);
            var input2 = Input.GetString(validator);
            Console.WriteLine($"Chuoi [{input1}] {(input1 == input2 ? "giong" : "khac")} chuoi [{input2}]");
                
            if (input1 == input2)
            {
                break;
            }
        }

        Console.WriteLine("1.8: So sanh hai chuoi, khong phan biet hoa thuong. Giong nhau thi di tiep qua 1.9.");
        while (true)
        {
            var input1 = Input.GetString(validator);
            var input2 = Input.GetString(validator);
            var equal = input1.ToLower() == input2.ToLower();
            Console.WriteLine($"Chuoi [{input1}] {(equal ? "giong" : "khac")} chuoi [{input2}]");

            if (equal)
            {
                break;
            }
        }

        Console.WriteLine("1.9: Thay the 'ABC' thanh 'DEF'. Co phan biet hoa, thuong.");
        Console.WriteLine($"Ket qua: {Input.GetString(validator).Replace("ABC", "DEF")}]");


        Console.WriteLine("1.10: Hien thi chuoi: Kinh chao ong [input]. Chuc ngon mieng.");
        Console.WriteLine($"Ket qua: Kinh chao ong {wordsCapitalized(Input.GetString(validator).Trim())}. Chuc ngon mieng.");



        Console.WriteLine("1.11: Dao nguoc cac ky tu cua chuoi.");
        Console.WriteLine($"Ket qua: '{reverse(Input.GetString(validator))}'");


        Console.WriteLine("1.12: Bo ky tu trang o DAU chuoi, lay count ky tu DAU cua chuoi");
        var count = Input.GetInt32(intValidator);
        var str = Input.GetString(validator);
        Console.WriteLine($"Ket qua: '{firstCount(str.TrimStart(), count)}'");

        Console.WriteLine("1.13: Bo ky tu trang o DAU VA CUOI chuoi, lay count ky tu DAU cua chuoi");
        count = Input.GetInt32(intValidator);
        str = Input.GetString(validator);
        Console.WriteLine($"Ket qua: '{firstCount(str.Trim(), count)}'");

        Console.WriteLine("1.14: Bo ky tu trang o DAU VA CUOI chuoi, lay count ky tu CUOI cua chuoi");
        count = Input.GetInt32(intValidator);
        str = Input.GetString(validator);
        Console.WriteLine($"Ket qua: '{lastCount(str.Trim(), count)}'");
    }

    private static bool intValidator(string? s)
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
        
        if (result < 0)
        {
            Console.WriteLine("So nho hon 0");
            return false;
        }
        return true;
    }

    private static string firstCount(string s, int count)
    {
        return s.Substring(0, Math.Min(count, s.Length));
    }

    private static string lastCount(string s, int count)
    {
        return s.Substring(Math.Max(0, s.Length - count), count);
    }

    private static string reverse(string testString)
    {
        return string.Join("", testString.Reverse());
    }

    private static int countNonSpaces(string testString)
    {
        return testString.Length - countSpaces(testString);
    }


    /// <summary>
    /// 1.1. Trả về false và thông báo nếu chuỗi null, rỗng, hoặc toàn trắng. 
    /// True với các trường hợp còn lại.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool validator(string? str)
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


    private static string removeAllWhites(string str)
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




    public static string wordsCapitalized(string str)
    {
        var result = "";
        
        for (int i = 0; i < str!.Length; i++)
        {
            if (i == 0 || (str[i-1] == ' '))
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

    public static int countSpaces(string str)
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
