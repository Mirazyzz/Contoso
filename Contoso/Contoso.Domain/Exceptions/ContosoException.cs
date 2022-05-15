using System.Globalization;

namespace Contoso.Domain.Exceptions
{
    public class ContosoException : Exception
    {
        public ContosoException() 
            : base() 
        {
        }

        public ContosoException(string message) 
            : base(message)
        {
        }

        public ContosoException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
