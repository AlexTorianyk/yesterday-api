using System;
using System.Net;
using System.Runtime.Serialization;

namespace YesterdayApi.Utilities.Exceptions
{
    [Serializable]
    public class BadRequestException : BaseHttpException
    {
        public BadRequestException(string message, string description)
            : base(message, description, (int)HttpStatusCode.BadRequest)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
