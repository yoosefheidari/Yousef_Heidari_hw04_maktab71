public class StudentCouse
{
    

    public Course _Course { get; set; }
    public float Score { get; set; }
    public StudentCouse(Course course)
    {
        _Course = course;
        Score = -1;
    }

}