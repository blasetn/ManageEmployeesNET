using AutoMapper;
using BLL.Models.Employee;
using DAL.Database.Models;

namespace BAL.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employees, EmployeeViewModel>().ReverseMap();
            CreateMap<Employees, EmployeeCreateModel>().ReverseMap();
            CreateMap<Employees, EmployeeDeleteModel>().ReverseMap();
        }
    }
}
