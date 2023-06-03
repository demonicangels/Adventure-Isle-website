using System.Runtime.Serialization;

namespace BusinessLogic
{
    [Serializable]
    public class FailedToRetrieveInformationException : Exception
    {
        public FailedToRetrieveInformationException()
        {
        }

        public FailedToRetrieveInformationException(string? message) : base(message)
        {
        }

        public FailedToRetrieveInformationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FailedToRetrieveInformationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}