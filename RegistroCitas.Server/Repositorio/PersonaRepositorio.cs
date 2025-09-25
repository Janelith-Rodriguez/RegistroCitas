using RegistroCitas.BD.Data;
using RegistroCitas.BD.Data.Entity;

namespace RegistroCitas.Server.Repositorio
{
    public class PersonaRepositorio : Repositorio<Persona>, IPersonaRepositorio
    {
        private readonly Context context;
        public PersonaRepositorio(Context context) : base(context)
        {
        }
    }
}
