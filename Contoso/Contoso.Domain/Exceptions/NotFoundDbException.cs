namespace Contoso.Domain.Exceptions
{
    public class NotFoundDbException : ContosoException
    {
        public NotFoundDbException()
            : base()
        {
        }

        public NotFoundDbException(string message)
            : base(message)
        {
        }
    }
}
