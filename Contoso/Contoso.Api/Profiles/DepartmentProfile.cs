using AutoMapper;
using Contoso.Domain.DTOs.Departments;
using Contoso.Domain.Entities;

namespace Contoso.Api.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentForCreateDto, Department>();
            CreateMap<DepartmentForUpdateDto, Department>();
        }
    }
}
