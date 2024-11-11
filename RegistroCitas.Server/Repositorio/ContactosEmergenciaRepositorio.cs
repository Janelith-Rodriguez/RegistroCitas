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
        //public async Task<ContactosEmergencia> SelectByCod(string cod)
        //{
        //    ContactosEmergencia? pepe = await context.ContactosEmergencias
        //                               .FirstOrDefaultAsync(x => x.Nombre == );
        //    return pepe;
        //}
    }
}
