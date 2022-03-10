public class HighSchoolStudent :Student
{
    public HighSchoolStudent(string email, string password) :base(email, password,GradeEnum.HighSchool)
    {


    }
    public override float CalculateAverage()
    {
        float sumOfScores = 0;
        float sumOfUnits=0;
        foreach(var studentCouse in base.Courses)
        {
            var course = (HighSchoolCourse)studentCouse._Course;
            sumOfScores += course.UnitOfCouse * studentCouse.Score;
            sumOfUnits += course.UnitOfCouse;
        }
        return sumOfScores/sumOfUnits;
    }
}
