public abstract class User
{
    public string Email { get; private set; }
    protected string Password { get; set; }
    public string? Name { get; set; }
    public string? Mobile { get; set; }
    public RoleEnum Role { get; private set; }
    public bool IsActive { get; private set; }

    public User(string email , string password , RoleEnum role)
    {
        Role = role;
        Email = email;
        Password = password;
        IsActive = false;
    }
    public User(string email, string password, RoleEnum role , string name , string mobile) :this(email , password , role)
    {
        Name = name;
        Mobile = mobile;
    }

    public void Activate()
    {
        IsActive = true;
    }
    public bool CheckPassword(string pass)
    {
        if(pass.ToLower()== Password.ToLower())
            return true;
        else
            return false;
    }
    public override string? ToString()
    {
        return $"{Name} - {Email} - {Mobile} - Role : {Role} - IsActive : {IsActive}";
    }
    public abstract string ChangePassword(string pass);
    public void ChangeEmail(string email)
    {
        Email = email;
    }
}


