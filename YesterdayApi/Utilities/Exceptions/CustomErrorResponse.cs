namespace YesterdayApi.Utilities.Exceptions
{
    public class CustomErrorResponse
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is CustomErrorResponse errorResponse)
                return Message == errorResponse.Message && Description == errorResponse.Description;
            return false;
        }
    }
}
