public class Teacher: Employee
{
    public Teacher(string profession, string name, int age, DateTime creationTime) : base(name, age, creationTime) {
        this.profession = profession;
    }

    public string profession;


    public override void promptData()
    {
        name = Input.GetString(ExerciseString.validator, "Nhap ten giao vien: ");
        age = Input.GetInt32(ExerciseInt.positiveValidator, "Nhap tuoi giao vien (DD/MM/YYYY): ");
        creationDate = Input.GetDateTime(ExerciseDateTime.validator, "Nhap thoi gian tao: ");
        profession = Input.GetString(ExerciseString.validator, "Nhap bo mon: ");
    }

    public override void ShowInfo() 
    {
        Console.WriteLine($"Toi la Giao Vien, {age} tuoi, toi ten la {name}.");
    }

    public override void ExtInfo()
    {
        Console.WriteLine($"Toi la Giao Vien ten {name}, thuoc bo mon {profession}, duoc tao ra luc {creationDate.ToString("HH:mm:ss dd/MM/yyyy")}.");
    }
}
