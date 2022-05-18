using AutoMapper;
using Contoso.Domain.DTOs.Instructors;
using Contoso.Domain.Entities;

namespace Contoso.Api.Profiles
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<Instructor, InstructorDto>();
            CreateMap<InstructorForCreateDto, Instructor>();
            CreateMap<InstructorForUpdateDto, Instructor>();
        }
    }
}
