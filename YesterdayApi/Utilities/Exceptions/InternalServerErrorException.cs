using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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
