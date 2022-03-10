public class CourseRepository : ICourseRepository
{
    string ICourseRepository.AddCourse(Course course)
    {
        if (DataStore.Courses.Any(item => item.Name.ToLower() == course.Name.ToLower() && item.Grade == course.Grade))
            return "Course Already Exists";
        DataStore.Courses.Add(course);
        return "OK";
    }

    List<Course> ICourseRepository.GetCourses()
    {
        return DataStore.Courses;
    }
}