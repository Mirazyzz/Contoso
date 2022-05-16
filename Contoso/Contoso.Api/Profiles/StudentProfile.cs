using AutoMapper;
using Contoso.Domain.DTOs.Students;
using Contoso.Domain.Entities;

namespace Contoso.Api.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
        }
    }
}
