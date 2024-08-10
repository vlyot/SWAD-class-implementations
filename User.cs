public class User
{
    // Ng Kai Chong
    public int UserID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

//Constructor - global
    public User(int userID, string name, string email, string password, string role)
    {
        UserID = userID;
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }
}
