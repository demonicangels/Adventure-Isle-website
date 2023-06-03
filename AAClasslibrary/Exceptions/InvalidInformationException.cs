using System.Runtime.Serialization;

namespace BusinessLogic
{
    [Serializable]
    public class InvalidInformationException : Exception
    {
        public InvalidInformationException()
        {
        }

        public InvalidInformationException(string? message) : base(message)
        {
        }

        public InvalidInformationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidInformationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}