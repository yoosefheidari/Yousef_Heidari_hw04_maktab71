public class HighSchoolCourse : Course
{
    public int UnitOfCouse { get; set; }
    public HighSchoolCourse(string name, GradeEnum grade,  int unit) : base(name, GradeEnum.HighSchool)
    {
        UnitOfCouse = unit;
    }

    public override string? ToString()
    {
        return $"{this.Name} - {Grade} - {UnitOfCouse} - {_Teacher.Name }";
    }
}

