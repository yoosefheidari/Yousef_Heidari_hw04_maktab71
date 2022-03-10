public interface IUserRepository
{
    string RegisterUser(User user);
    User? GetUser(string Email);
    User? GetCurrentUser();
    string Login(string email , string password);
    List<User> GetUsers();
    void LogOff();
}
