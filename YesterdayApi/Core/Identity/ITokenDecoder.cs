namespace YesterdayApi.Core.Identity
{
    public interface ITokenDecoder
    {
        int GetUserId(string authHeader);
    }
}
