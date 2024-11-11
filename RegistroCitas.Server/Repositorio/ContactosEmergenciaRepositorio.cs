using RegistroCitas.BD.Data;
using RegistroCitas.BD.Data.Entity;

namespace RegistroCitas.Server.Repositorio
{
    public class ContactosEmergenciaRepositorio : Repositorio<ContactosEmergencia>, IContactosEmergenciaRepositorio
    {
        public ContactosEmergenciaRepositorio(Context context) : base(context)
        {
            
        }

    }
}
