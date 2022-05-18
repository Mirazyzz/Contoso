using AutoMapper;
using Contoso.Domain.DTOs.Enrollments;
using Contoso.Domain.Entities;

namespace Contoso.Api.Profiles
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentDto>();
        }
    }
}
