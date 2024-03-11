using static System.Net.Mime.MediaTypeNames;

public class ExerciseList
{
    public static void AutomatedTest()
    {
        Console.WriteLine("List<int> TEST");
        Console.WriteLine();

        /// TODO: Nhớ sửa thành 10 theo đề bài
        int count = 10;
        int x;
        List<int> list = [];

        Console.WriteLine($"1.1: Mot danh sach ngau nhien:\n {ToString(GetRandomListInt())}\n");

        Console.WriteLine($"1.2: Nhap {count} so bat ky. In ra sap xep tang dan.");
        list = Input.GetListInt(count);
        list.Sort();
        Console.WriteLine($"Ket qua: {ToString(list)}");

        Console.WriteLine($"1.3: Nhap {count} so bat ky. In ra day so nguoc lai.");
        list = Input.GetListInt(count);
        list.Reverse();
        Console.WriteLine($"Ket qua: {ToString(list)}");

        Console.WriteLine($"1.4: Nhap {count} so bat ky. Nhap them mot so X. Bo di cac so nho hon X.");
        x = Input.GetInt32(ExerciseInt.Validator, "Nhap so nguyen X: ");
        Console.WriteLine($"Nhap day {count} so: ");
        list = Input.GetListInt(count);
        Console.WriteLine($"Ket qua: {ToString(RemoveWhereLessThan(list, x))}");

        Console.WriteLine($"1.5: Nhap {count} so bat ky. Nhap them mot so X. Bo di cac so chia het cho X.");
        x = Input.GetInt32(ExerciseInt.NonZeroValidator, "Nhap so nguyen X: ");
        Console.WriteLine($"Nhap day {count} so: ");
        list = Input.GetListInt(count);
        Console.WriteLine($"Ket qua: {ToString(RemoveWhereDivide(list, x))}");

        Console.WriteLine($"1.6: Nhap {count} so bat ky. Nhap them mot so X. Cong them X neu so do be hon X.");
        x = Input.GetInt32(ExerciseInt.Validator, "Nhap so nguyen X: ");
        Console.WriteLine($"Nhap day {count} so: ");
        list = Input.GetListInt(count);
        Console.WriteLine($"Ket qua: {ToString(AddIfLessThan(list, x))}");

        Console.WriteLine($"1.7: Nhap {count} so bat ky. Nhap them mot so X > 0. In X so cuoi ra man hinh.");
        x = Input.GetInt32(ExerciseInt.PositiveValidator, "Nhap so nguyen X: ");
        x = Math.Min(x, count);
        Console.WriteLine($"Nhap day {count} so: ");
        list = Input.GetListInt(count);
        list = list.TakeLast(x).ToList();
        Console.WriteLine($"Ket qua: {ToString(list)}");

        Console.WriteLine($"1.8: Nhap {count} so bat ky. Nhap them mot so X > 0. In X so cuoi ra man hinh theo chieu nguoc lai.");
        x = Input.GetInt32(ExerciseInt.PositiveValidator, "Nhap so nguyen X: ");
        x = Math.Min(x, count);
        Console.WriteLine($"Nhap day {count} so: ");
        list = Input.GetListInt(count);
        list.Reverse();
        list = list.Take(x).ToList();
        Console.WriteLine($"Ket qua: {ToString(list)}");

        Console.WriteLine($"1.9: Nhap so X > 0. In ra nhieu nhat {count} so Fibonacci cuoi cung < X.");
        x = Input.GetInt32(ExerciseInt.PositiveValidator, "Nhap so nguyen X: ");
        list = GetFibonacci(x);
        list = list.TakeLast(Math.Min(count, list.Count)).ToList();
        Console.WriteLine($"Ket qua: {ToString(list)}");
    }

    /// <summary>
    /// Return an array of Fibonacci numbers smaller than 'threshold'
    /// </summary>
    /// <param name="threshold"></param>
    /// <returns></returns>
    public static List<int> GetFibonacci(int threshold)
    {
        if (threshold < 1)
        {
            return [];
        }
        List<int> result = [1, 1];
        while (true)
        {
            var nextElement = result[^2] + result.Last();
            if (nextElement > threshold)
            {
                break;
            }
            result.Add(nextElement);
        }
        return result;
    }

    public static List<int> AddIfLessThan(List<int> list, int threshold)
    {
        return Map(list, (i) => i < threshold ? i + threshold : i);
    }

    public static List<int> Map(List<int> list, Func<int, int> mapper)
    {
        for (int i = 0; i < list.Count; ++i)
        {
            list[i] = mapper(list[i]);
        }
        return list;
    }

    public static List<int> RemoveWhereLessThan(List<int> list, int threshold)
    {
        return RemoveWhere(list, (i) => i < threshold);
    }

    public static List<int> RemoveWhereDivide(List<int> list, int divider)
    {
        return RemoveWhere(list, (i) => i % divider == 0);
    }

    public static List<T> RemoveWhere<T>(List<T> list, Predicate<T> pred)
    {
        List<int> removeIdx = [];
        for (int i = list.Count - 1; i >= 0; --i)
        {
            if (pred(list[i]))
            {
                removeIdx.Add(i);
            }

        }
        foreach (int idx in removeIdx)
        {
            list.RemoveAt(idx);
        }
        return list;
    }

    public static List<int> GetRandomListInt()
    {
        var rand = new Random();
        var list = new List<int>();
        for (int i = 0; i < 10; ++i)
        {
            list.Add(rand.Next());
        }
        return list;
    }

    public static string ToString(List<int> list)
    {
        return $"[{String.Join(", ", list)}]";
    }

}
