public class CourseRepositoryFile : ICourseRepository
{
    
    private string path = @"C:\Users\Yousef1371\Desktop\ElectronicSchool\ElectronicSchool\02-Infrastructure\DataStore";
    
    public string AddCourse(Course course)
    {
        if (course.Grade == GradeEnum.MiddleSchool)
        {
            List<MiddleSchoolCourse> courses = new List<MiddleSchoolCourse>();
            courses = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MiddleSchoolCourse>>(File.ReadAllText($@"{path}\MiddleSchoolCourses.txt"));
            if (courses == null)
            {
                courses = new List<MiddleSchoolCourse>();
            }
            MiddleSchoolCourse a = (MiddleSchoolCourse)course;
            courses.Add(a);
            File.WriteAllText($@"{path}\MiddleSchoolCourses.txt", Newtonsoft.Json.JsonConvert.SerializeObject(courses));
            return "OK";
        }
        else
        {
            List<HighSchoolCourse> courses = new List<HighSchoolCourse>();
            courses = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HighSchoolCourse>>(File.ReadAllText($@"{path}\HighSchoolCourses.txt"));
            if (courses == null)
            {
                courses = new List<HighSchoolCourse>();
            }
            HighSchoolCourse a = (HighSchoolCourse)course;
            courses.Add(a);
            File.WriteAllText($@"{path}\HighSchoolCourses.txt", Newtonsoft.Json.JsonConvert.SerializeObject(courses));
            return "OK";
        }
        
    }

    public List<Course> GetCourses()
    {        
        var courseListL=Newtonsoft.Json.JsonConvert.DeserializeObject<List<MiddleSchoolCourse>>(File.ReadAllText($@"{path}\MiddleSchoolCourses.txt"));
        List<Course> newcourses = new List<Course>();
        foreach(var course in courseListL)
        {
            newcourses.Add((Course)course);
        }

        var courseListH = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HighSchoolCourse>>(File.ReadAllText($@"{path}\HighSchoolCourses.txt"));
        
        foreach (var course in courseListH)
        {
            newcourses.Add((Course)course);
        }
        return newcourses;
    }
}