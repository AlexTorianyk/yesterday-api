using System;
using System.Net;
using System.Runtime.Serialization;

namespace YesterdayApi.Utilities.Exceptions
{
    [Serializable]
    public class UnauthorizedException : BaseHttpException
    {
        public UnauthorizedException(string message, string description)
            : base(message, description, (int)HttpStatusCode.Unauthorized)
        {
        }

        protected UnauthorizedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
