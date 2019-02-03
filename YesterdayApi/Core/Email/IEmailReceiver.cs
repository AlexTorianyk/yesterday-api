namespace YesterdayApi.Core.Email
{
    public interface IEmailReceiver
    {
        string Email { get; set; }
        string UserName { get; set; }
    }
}