using mTech.Models;
using AutoMapper;
namespace mTech.App
{
    public class employeeMaping : Profile
    {
        public employeeMaping()
        {

            CreateMap<Employee, EmployeeInfo>();
        }
    }
}
