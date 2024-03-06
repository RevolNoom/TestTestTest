using System.Data;
using static System.Net.Mime.MediaTypeNames;

public class ExerciseDateTime
{
    public static void automatedTest()
    {
        Console.WriteLine("DATETIME TEST");
        DateTime datetime;


        datetime = DateTime.Today;
        Console.WriteLine($"1.1: Hom nay la {dayName[datetime.DayOfWeek]}, thang {datetime.Month}, nam {datetime.Year}");
        Console.WriteLine();

        Console.WriteLine("1.2: In ra ngay duoc nhap");
        datetime = Input.GetDateTime(validator);
        Console.WriteLine($"Hom nay la {dayName[datetime.DayOfWeek]}, thang {datetime.Month}, nam {datetime.Year}");
        Console.WriteLine();

        Console.WriteLine("1.3: In ra ngay hom sau");
        datetime = GetTomorrow(Input.GetDateTime(validator));
        Console.WriteLine($"Hom sau la {dayName[datetime.DayOfWeek]}, thang {datetime.Month}, nam {datetime.Year}");
        Console.WriteLine();


        Console.WriteLine("1.4: In ra ngay hom qua");
        datetime = GetYesterday(Input.GetDateTime(validator));
        Console.WriteLine($"Hom qua la {dayName[datetime.DayOfWeek]}, thang {datetime.Month}, nam {datetime.Year}");
        Console.WriteLine();

        Console.WriteLine("1.5: Cho biet ngay duoc nhap la tuong lai, hien tai, hay qua khu.");
        datetime = Input.GetDateTime(validator);
        if (IsFutureDay(DateTime.Today, datetime)) Console.WriteLine("Ngay tuong lai");
        if (IsSameDay(DateTime.Today, datetime)) Console.WriteLine("Ngay hom nay");
        if (IsPastDay(DateTime.Today, datetime)) Console.WriteLine("Ngay qua khu");
        Console.WriteLine();

        Console.WriteLine("1.6: In ra du the loai format ngay.");
        datetime = Input.GetDateTime(validator);
        Console.WriteLine($"Ngay/Thang/Nam: {datetime.ToString("dd/MM/yyyy")}");
        Console.WriteLine($"Nam/Thang/Ngay: {datetime.ToString("yyyy/MM/dd")}");
        Console.WriteLine($"Thang/Nam: {datetime.ToString("MM/yyyy")}");
        Console.WriteLine($"Thang-Nam: {datetime.ToString("MM-yyyy")}");
        Console.WriteLine();

        Console.WriteLine("1.7: In ra 10 ngay truoc la thu may.");
        datetime = Input.GetDateTime(validator).AddDays(-10);
        Console.WriteLine($"{datetime.ToString("dd/MM/yyyy")} la {dayName[datetime.DayOfWeek]}");
        Console.WriteLine();


        Console.WriteLine("1.8: In ra cuoi thang nay la thu may.");
        datetime = GetLastDayOfMonth(Input.GetDateTime(validator));
        Console.WriteLine($"{datetime.ToString("dd/MM/yyyy")} la {dayName[datetime.DayOfWeek]}");
        Console.WriteLine();

        Console.WriteLine("1.9: In ra cuoi nam nay la thu may.");
        datetime = GetLastDayOfYear(Input.GetDateTime(validator));
        Console.WriteLine($"{datetime.ToString("dd/MM/yyyy")} la {dayName[datetime.DayOfWeek]}");
        Console.WriteLine();

        Console.WriteLine("1.10: In ra hai ngay cach nhau bao nhieu ngay.");
        datetime = Input.GetDateTime(validator);
        var datetime2 = Input.GetDateTime(validator);
        Console.WriteLine($"{datetime2.ToString("dd/MM/yyyy")} cach {datetime.ToString("dd/MM/yyyy")} {datetime2.Subtract(datetime).Days} ngay.");
        Console.WriteLine();

    }

    /// <summary>
    /// Return true if `compare` is a day in the future compared to `date`
    /// </summary>
    /// <param name="date"></param>
    /// <param name="compare"></param>
    /// <returns></returns>
    public static bool IsFutureDay(DateTime date, DateTime compare)
    {
        return compare.Subtract(date).TotalDays > 0 && compare.Day != date.Day;
    }

    /// <summary>
    /// Return true if `compare` is the same day as `date`
    /// </summary>
    /// <param name="date"></param>
    /// <param name="compare"></param>
    /// <returns></returns>
    public static bool IsSameDay(DateTime date, DateTime compare)
    {
        return !IsPastDay(date, compare) && !IsFutureDay(date, compare);
    }


    /// <summary>
    /// Return true if `compare` is a day in the past compared to `date`
    /// </summary>
    /// <param name="date"></param>
    /// <param name="compare"></param>
    /// <returns></returns>
    public static bool IsPastDay(DateTime date, DateTime compare)
    {
        return compare.Subtract(date).TotalDays < 0 && compare.Day != date.Day;
    }

    public static DateTime GetTomorrow(DateTime dateTime)
    {
        return dateTime.AddDays(1);
    }


    public static DateTime GetYesterday(DateTime dateTime)
    {
        return dateTime.AddDays(-1);
    }


    public static DateTime GetLastDayOfMonth(DateTime dateTime)
    {
        var result = new DateTime(dateTime.Year + (dateTime.Month + 1) / 12, (dateTime.Month + 1) % 12, 1);
        return result.AddDays(-1);
    }

    public static DateTime GetLastDayOfYear(DateTime dateTime)
    {
        var result = new DateTime(dateTime.Year + 1, 1, 1);
        return result.AddDays(-1);
    }

    public static bool validator(string? s) {
        DateTime dontCare;
        var isDateTime = DateTime.TryParseExact(s, 
            "d/M/yyyy", 
            System.Globalization.CultureInfo.InvariantCulture, 
            System.Globalization.DateTimeStyles.None, 
            out dontCare);
        if (!isDateTime)
        {
            Console.WriteLine("Ngay thang khong dung dinh dang");
        }
        return isDateTime;
    }

    public static Dictionary<DayOfWeek, String> dayName = new Dictionary<DayOfWeek, string>
    {
        [DayOfWeek.Sunday] = "chu nhat",
        [DayOfWeek.Monday] = "thu hai",
        [DayOfWeek.Tuesday] = "thu ba",
        [DayOfWeek.Wednesday] = "thu tu",
        [DayOfWeek.Thursday] = "thu nam",
        [DayOfWeek.Friday] = "thu sau",
        [DayOfWeek.Saturday] = "thu bay",
    };
}
