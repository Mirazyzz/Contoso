namespace Contoso.Domain.Interfaces.Repostiory
{
    public interface ICommonRepository
    {
        IStudentRepository Student { get; }
        ICityRepository City { get; }

        Task SaveChangesAsync();
    }
}
