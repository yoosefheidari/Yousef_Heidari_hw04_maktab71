public class UserRepository : IUserRepository
{
    public User? GetCurrentUser()
    {
        return DataStore.CurrentUser;
    }

    public User? GetUser(string Email)
    {
       return DataStore.Users.FirstOrDefault(u => u.Email == Email);
    }

    public List<User> GetUsers()
    {
        return DataStore.Users;
    }

    public string Login(string email, string password)
    {
        var user= DataStore.Users.FirstOrDefault(p=>p.Email.ToLower() == email.ToLower());
        if (user == null)
            return "This User Dose Not Exist.";
        if (!user.CheckPassword(password))
            return "Your Password Is Incorrect.";
        if (!user.IsActive)
            return "This User Is Not Active.";
        DataStore.CurrentUser = user;
        return "OK";
    }

    public void LogOff()
    {
        DataStore.CurrentUser = null;
    }

    public string RegisterUser(User user)
    {
        if (DataStore.Users.Any(u => u.Email == user.Email))
            return "This user already exists";
        DataStore.Users.Add(user);
        return "OK";
    }
}
