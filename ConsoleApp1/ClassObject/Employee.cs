public class Employee
{
    public static void automatedTest()
    {
        Console.WriteLine("TEST INHERITANCE");
        Console.WriteLine();

        while (true)
        {
            Employee polymorphicHuman;

            int type = Input.GetInt32(typeValidator, "1 la Nhan vien, 2 la Sinh vien, 3 la Giao vien: ");
            switch(type)
            {
                case 1:
                    polymorphicHuman = new Employee("", 0, DateTime.Today);
                    break;
                case 2:
                    polymorphicHuman = new Student("", "", 0, DateTime.Today);
                    break;
                default: // 3
                    polymorphicHuman = new Teacher("", "", 0, DateTime.Today);
                    break;
            }

            polymorphicHuman.promptData();
            polymorphicHuman.ShowInfo();
            polymorphicHuman.ExtInfo();

            if (!ExerciseTemplate.testMore())
            {
                break;
            }
        }

    }

    static private bool typeValidator(string? type)
    {
        return ExerciseInt.positiveValidator(type) && Int32.Parse(type!) < 4;
    }

    public Employee(string name, int age, DateTime creationDate)
    {
        this.name = name;
        this.age = age;
        this.creationDate = creationDate;
    }

    virtual public void promptData()
    {
        name = Input.GetString(ExerciseString.validator, "Nhap ten nhan vien: ");
        age = Input.GetInt32(ExerciseInt.positiveValidator, "Nhap tuoi nhan vien: ");
        creationDate = Input.GetDateTime(ExerciseDateTime.validator, "Nhap thoi gian tao (DD/MM/YYYY): ");
    }

    public string name { get; set; }

    public int age { get; set; }

    public DateTime creationDate { get; set; }

    virtual public void ShowInfo()
    {
        Console.WriteLine($"Toi ten la {name}, {age} tuoi.");
    }
    virtual public void ExtInfo()
    {
        Console.WriteLine($"Toi ten la {name}, duoc tao ra luc {creationDate.ToString("HH:mm:ss dd/MM/yyyy")}.");
    }
}
