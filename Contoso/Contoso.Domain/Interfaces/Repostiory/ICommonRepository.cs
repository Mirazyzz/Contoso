namespace Contoso.Domain.Interfaces.Repostiory
{
    public interface ICommonRepository
    {
        IStudentRepository Student { get; }

        Task SaveChangesAsync();
    }
}
