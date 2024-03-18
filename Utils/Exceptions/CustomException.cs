using System.Runtime.Serialization;

namespace Utils.Exceptions
{
    [Serializable]
    public class CustomException : Exception
    {
        public List<string> Messages { get; set; }

        public CustomException()
        {

        }

        public CustomException(List<string> messages)
        {
            Messages = messages;
        }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
