using System.Globalization;

namespace Contoso.Domain.Exceptions
{
    public class EntityAlreadyExistException : Exception
    {
        public EntityAlreadyExistException()
            : base()
        {
        }

        public EntityAlreadyExistException(string message)
            : base(message)
        {
        }

        public EntityAlreadyExistException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
