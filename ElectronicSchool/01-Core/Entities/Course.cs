public abstract class Course
{
    public string Name { get; set; }
    public GradeEnum Grade { get; set; }
    public Teacher _Teacher { get; set; }
    public Course(string name,GradeEnum grade)
    {
        Name = name;
        Grade = grade;
    }
    public override string? ToString()
    {
        return $"{this.Name} - {Grade} - {_Teacher.Name }";
    }
}

