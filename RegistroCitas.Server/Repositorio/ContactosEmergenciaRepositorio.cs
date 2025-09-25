using Microsoft.EntityFrameworkCore;
using RegistroCitas.BD.Data;
using RegistroCitas.BD.Data.Entity;

namespace RegistroCitas.Server.Repositorio
{
    public class ContactosEmergenciaRepositorio : Repositorio<ContactosEmergencia>, IContactosEmergenciaRepositorio
    {
        private readonly Context context;

        public ContactosEmergenciaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<ContactosEmergencia> SelectById(int id)
        {
            ContactosEmergencia? pepe = await context.Set<ContactosEmergencia>().AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return pepe;
        }
        
    }
}
