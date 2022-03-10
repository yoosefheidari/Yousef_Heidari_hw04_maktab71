public class Admin : User
{
    public Admin(string email, string password) : base(email, password, RoleEnum.Admin)
    {
        base.Name = "Admin";
        base.Mobile = "09121234567";
    }

    public override string ChangePassword(string pass)
    {
        return "The Admin Password Can Not Be Changed.";
    }
    
}