using System.Runtime.Serialization;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class FailedToUpdateException : Exception
    {
        public FailedToUpdateException()
        {
        }

        public FailedToUpdateException(string? message) : base(message)
        {
        }

        public FailedToUpdateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FailedToUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}