public static class DataStore
{
    public static List<User> Users { get; set; }
    public static User? CurrentUser { get; set; }
    public static List<Course> Courses { get; set; }

    static DataStore()
    {
        Users = new List<User>();
        var admin = new Admin("admin", "123");
        admin.Activate();
        Users.Add(admin);
        CurrentUser =null;
        Courses = new List<Course>();
    }
}
