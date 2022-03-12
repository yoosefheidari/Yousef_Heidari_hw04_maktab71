public class UserRepositoryFile : IUserRepository
{
    private User? current = null;
    private string path= @"C:\Users\Yousef1371\Desktop\ElectronicSchool\ElectronicSchool\02-Infrastructure\DataStore";
    public User? GetCurrentUser()
    {
        return current;
    }

    public User? GetUser(string Email)
    {
        List<User> users = new List<User>();
        users=Newtonsoft.Json.JsonConvert.DeserializeObject<List<User?>>(path+"UserFile.txt");
        return users.FirstOrDefault(p=>p.Email==Email);
        
    }

    public List<User> GetUsers()
    {
        List<User> users = new List<User>();
        return users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User?>>(path + "UserFile.txt");
    }

    public string Login(string email, string password)
    {
        List<User> users = new List<User>();
        users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User?>>(path + "UserFile.txt");
        var user = users.FirstOrDefault(p=>p.Email==email);
        if (user == null)
            return "This User Dose Not Exist.";
        if (!user.CheckPassword(password))
            return "Your Password Is Incorrect.";
        if (!user.IsActive)
            return "This User Is Not Active.";
        current = user;
        return "OK";
    }

    public void LogOff()
    {
        current= null;
    }

    public string RegisterUser(User user)
    {
        List<User> users = new List<User>();
        users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User?>>(path + "UserFile.txt");
        if (users.Any(u => u.Email == user.Email))
            return "This user already exists";
        users.Add(user);
        File.WriteAllText(path + "UserFile.txt", Newtonsoft.Json.JsonConvert.SerializeObject(users));
        return "OK";
    }
}