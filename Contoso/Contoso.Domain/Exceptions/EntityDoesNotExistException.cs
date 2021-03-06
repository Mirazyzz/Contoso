using System.Globalization;

namespace Contoso.Domain.Exceptions
{
    public class EntityDoesNotExistException : Exception
    {
        public EntityDoesNotExistException() 
            : base()
        {
        }

        public EntityDoesNotExistException(string message)
            : base(message)
        {
        }

        public EntityDoesNotExistException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
