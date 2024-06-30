using AutoMapper;
using Sistema_gestion_funeraria.Models.DTOs.Empleados;
using Sistema_gestion_funeraria.Models;
using Sistema_gestion_funeraria.Models.DTOs.TipoIdentificaciones;

namespace Sistema_gestion_funeraria.Models.DTOs
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmpleadoGetDTO, Empleado>().ReverseMap();
            CreateMap<EmpleadoInsertDTO, Empleado>().ReverseMap();
            CreateMap<EmpleadoUpdateDTO, Empleado>().ReverseMap();

            CreateMap<TipoIdentificacioneGetDTO, TipoIdentificacione>().ReverseMap();
            CreateMap<TipoIdentificacioneInsertDTO, TipoIdentificacione>().ReverseMap();
            CreateMap<TipoIdentificacioneUpdateDTO, TipoIdentificacione>().ReverseMap();
        }
    }
}
