public class Student :User
{
    public GradeEnum Grade { get; set; }
    public List<StudentCouse> Courses { get; set; }
    public Student(string email, string password, GradeEnum grade):base(email,password,RoleEnum.Student)
    {
        Courses= new List<StudentCouse>();
        Grade=grade;
    }
    public virtual float CalculateAverage()
    {       
       return Courses.Average(p => p.Score);
    }
    public override string ChangePassword(string pass)
    {
        if (pass.Length < 6)
            return "New Password Is Less Than 6 Characters.";
        base.Password=pass;
        return "OK";
    }
}
