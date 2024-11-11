using Microsoft.AspNetCore.Mvc;
using RegistroCitas.BD.Data.Entity;
using RegistroCitas.BD.Data;
using Microsoft.EntityFrameworkCore;

namespace RegistroCitas.Server.Controllers
{
    public class ContactosEmergenciasControllers : ControllerBase
    {
        private readonly Context context;

        public ContactosEmergenciasControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactoEmergencia>>> Get()
        {
            return await context.ContactosEmergencias.ToListAsync();
        }


        [HttpGet("{id:int}")] //api/ContactoEmergencias/2
        public async Task<ActionResult<ContactoEmergencia>> Get(int id)
        {
            ContactoEmergencia? pepe = await context.ContactosEmergencias
                .FirstOrDefaultAsync(x => x.Id == id);
            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(ContactoEmergencia entidad)
        {
            try //por si existe un error, puedo responder algunas cosas (que me de un entero o resultado de la acticion
            {
                context.ContactosEmergencias.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/ContactosEmergencias/2
        public async Task<ActionResult> Put(int id, [FromBody] ContactoEmergencia entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var pepe = await context.ContactosEmergencias.
                             Where(e => e.Id == id).FirstOrDefaultAsync();

            if (pepe == null)
            {
                return NotFound("No existe el contacto de emergencia buscado.");
            }

            pepe.Nombre = entidad.Nombre;
            pepe.Relacion = entidad.Relacion;
            pepe.Telefono = entidad.Telefono;
            pepe.Email = entidad.Email;
            pepe.Activo = entidad.Activo;

            try
            {
                context.ContactosEmergencias.Update(pepe);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/ContactosEmergencias/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.ContactosEmergencias.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El tipo de Contacto de emergencia {id} no existe.");
            }
            ContactoEmergencia EntidadABorrar = new ContactoEmergencia();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
