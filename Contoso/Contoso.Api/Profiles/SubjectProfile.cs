using AutoMapper;
using Contoso.Domain.DTOs.Subjects;
using Contoso.Domain.Entities;

namespace Contoso.Api.Profiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectForCreateDto, SubjectDto>();
            CreateMap<SubjectForUpdateDto, SubjectDto>();
        }
    }
}
