using System;
using System.Net;

namespace YesterdayApi.Utilities.Exceptions
{
    [Serializable]
    public class ObjectNotFoundException : BaseCustomException
    {
        public ObjectNotFoundException(string message, string description)
            : base(message, description, (int)HttpStatusCode.NotFound)
        {
        }
    }
}