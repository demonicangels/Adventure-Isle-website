using System.Runtime.Serialization;

namespace BusinessLogic
{
    [Serializable]
    public class CouldntFindUserException : Exception
    {
        public CouldntFindUserException()
        {
        }

        public CouldntFindUserException(string? message) : base(message)
        {
        }

        public CouldntFindUserException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CouldntFindUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}