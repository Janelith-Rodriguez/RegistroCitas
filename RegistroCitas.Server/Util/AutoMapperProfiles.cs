using AutoMapper;
using RegistroCitas.BD.Data.Entity;
using RegistroCitas.Shared.DTO;

namespace RegistroCitas.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearContactosEmergenciaDTO, ContactosEmergencia>();
            
            //CreateMap<CrearPersonaDTO, Persona>();
            
            //CreateMap<CrearTDocumentoDTO, TDocumento>();
        }
        
    }
}
