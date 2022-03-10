public class Teacher : User
{
    public GradeEnum Grade { get; set; }
    public List<Course> Courses { get; set; }

    public Teacher(string email, string password, GradeEnum grade) : base(email, password, RoleEnum.Teacher)
    {
        Grade = grade;
        Courses = new List<Course>();
    }
    public override string ChangePassword(string pass)
    {
        if (pass.Length < 8)
            return "New Password Is Less Than 8 Characters.";
        base.Password = pass;
        return "OK";
    }
    public virtual float CalculateSalary()
    {
        return Courses.Count * 1000000;
    }
}