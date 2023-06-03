using System.Runtime.Serialization;

namespace BusinessLogic
{
    [Serializable]
    public class CouldntDeleteException : Exception
    {
        public CouldntDeleteException()
        {
        }

        public CouldntDeleteException(string? message) : base(message)
        {
        }

        public CouldntDeleteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CouldntDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}