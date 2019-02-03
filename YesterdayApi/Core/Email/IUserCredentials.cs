namespace YesterdayApi.Core.Email
{
    public interface IUserCredentials
    {
        string Email { get; set; }
        string UserName { get; set; }
    }
}