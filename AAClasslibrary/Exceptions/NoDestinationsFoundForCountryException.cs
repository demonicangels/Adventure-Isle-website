using System.Runtime.Serialization;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class NoDestinationsFoundForCountryException : Exception
    {
        public NoDestinationsFoundForCountryException()
        {
        }

        public NoDestinationsFoundForCountryException(string? message) : base(message)
        {
        }

        public NoDestinationsFoundForCountryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoDestinationsFoundForCountryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}