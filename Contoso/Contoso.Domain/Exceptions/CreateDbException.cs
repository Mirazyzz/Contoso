namespace Contoso.Domain.Exceptions
{
    public class CreateDbException : ContosoException
    {
        public CreateDbException(string message)
            : base(message)
        {
        }

        public CreateDbException(string message, params object[] args)
            : base(message, args)
        {
        }
    }
}
