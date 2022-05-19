using Contoso.Domain.Interfaces.Repostiory;
using Contoso.Infrastructure;

namespace Contoso.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly ContosoDbContext _context;
        
        private IStudentRepository? _studentRepository;
        private ICityRepository? _cityRepository;

        public CommonRepository(ContosoDbContext context)
        {
            _context = context;
        }

        public IStudentRepository Student
        {
            get => _studentRepository ??= new StudentRepository(_context);
        }

        public ICityRepository City
        {
            get => _cityRepository ??= new CityRepository(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
