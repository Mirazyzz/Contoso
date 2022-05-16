﻿using Contoso.Domain.Interfaces.Repostiory;
using Contoso.Infrastructure;

namespace Contoso.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly ContosoDbContext _context;
        
        private IStudentRepository? _studentRepository;

        public CommonRepository(ContosoDbContext context)
        {
            _context = context;
        }

        public IStudentRepository Student
        {
            get => _studentRepository ??= new StudentRepository(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
