using AutoMapper;
using Sistema_gestion_funeraria.Models.DTOs.Empleados;
using Sistema_gestion_funeraria.Models;

namespace Sistema_gestion_funeraria.Models.DTOs
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmpleadoGetDTO, Empleado>().ReverseMap();
            CreateMap<EmpleadoInsertDTO, Empleado>().ReverseMap();
            CreateMap<EmpleadoUpdateDTO, Empleado>().ReverseMap();
        }
    }
}
