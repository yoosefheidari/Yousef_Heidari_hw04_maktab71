public class HighSchoolTeacher : Teacher
{
    public HighSchoolTeacher(string email, string password) : base(email, password,GradeEnum.HighSchool)
    {

    }
    public override float CalculateSalary()
    {
        
        var units = 0;
        foreach (var item in base.Courses)
        {            
            var holder = (HighSchoolCourse)item;
            units = units + holder.UnitOfCouse;
            
        }
        return units*1000000;
    }
}