public class UserModel
{
    public string Email{get;set;}
    public string Role{get;set;}="Customer";
    public UserModel(string email)
    {
        Email = email;
    }
}