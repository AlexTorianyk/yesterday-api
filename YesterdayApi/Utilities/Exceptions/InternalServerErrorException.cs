using System;
using System.Net;
using System.Runtime.Serialization;

namespace YesterdayApi.Utilities.Exceptions
{
    [Serializable]
    public class InternalServerErrorException : BaseHttpException
    {
        public InternalServerErrorException(string message, string description)
            : base(message, description, (int)HttpStatusCode.InternalServerError)
        {
        }

        protected InternalServerErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
