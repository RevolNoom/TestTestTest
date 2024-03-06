using static System.Net.Mime.MediaTypeNames;

public class ExerciseDecimal
{
    public static void automatedTest(string b = "1000,000,234,567.89")
    {
        Console.WriteLine("DOUBLE AUTOMATED TEST");
        Console.WriteLine($"1.1 & 1.2: Nhap mot so thap phan, roi convert lai thanh string co ngan cach.");
        var input = Input.GetDouble(validator);
        Console.WriteLine($"Chuoi hop le. Sau khi convert: {toString(input)}");
        Console.WriteLine();
    }

    public static bool validator(string? d) {
        double dontCare;
        if (!double.TryParse(d, out dontCare))
        {
            Console.WriteLine("Khong phai chuoi so thap phan");
            return false;
        }

        var numberParts = d.Split('.');
        /// Lấy phần nguyên,
        /// Nếu có dấu ',' thì tất cả cặp 3 số đằng sau đều phải có ','
        var integerParts = numberParts[0].Split(',');
        for (int i = 1; i < integerParts.Length; ++i)
        {
            if (integerParts[i].Length != 3)
            {
                Console.WriteLine("Khong phai chuoi so thap phan");
                return false;
            }
        }

        /// Nếu chỉ có phần nguyên và validate xong rồi thì về thôi
        if (numberParts.Length == 1)
        {
            return true;
        }

        /// Lấy phần thập phân,
        /// Nếu có dấu ',' thì tất cả cặp 3 số đằng trước đều phải có ','
        var decimalParts = d.Split('.')[1].Split(',');
        for (int i = 0; i < decimalParts.Length-1; ++i)
        {
            if (decimalParts[i].Length != 3)
            {
                Console.WriteLine("Khong phai chuoi so thap phan");
                return false;
            }
        }

        return true;
    }

    public static string toString(double d)
    {
        return d.ToString("N2");
    }
}
