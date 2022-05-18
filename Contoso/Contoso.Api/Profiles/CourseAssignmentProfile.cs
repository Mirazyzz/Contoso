using AutoMapper;
using Contoso.Domain.DTOs.CourseAssignments;
using Contoso.Domain.Entities;

namespace Contoso.Api.Profiles
{
    public class CourseAssignmentProfile : Profile
    {
        public CourseAssignmentProfile()
        {
            CreateMap<CourseAssignment, CourseAssignmentDto>();
            CreateMap<CourseAssignmentForCreateDto, CourseAssignment>();
            CreateMap<CourseAssignmentForUpdateDto, CourseAssignment>();
        }
    }
}
