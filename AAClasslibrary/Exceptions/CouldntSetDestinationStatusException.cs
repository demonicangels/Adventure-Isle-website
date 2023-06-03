using System.Runtime.Serialization;

namespace BusinessLogic
{
    [Serializable]
    public class CouldntSetDestinationStatusException : Exception
    {
        public CouldntSetDestinationStatusException()
        {
        }

        public CouldntSetDestinationStatusException(string? message) : base(message)
        {
        }

        public CouldntSetDestinationStatusException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CouldntSetDestinationStatusException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}