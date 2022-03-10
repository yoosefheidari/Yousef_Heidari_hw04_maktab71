public interface ICourseRepository
{
    string AddCourse(Course course);
    List<Course> GetCourses();
}