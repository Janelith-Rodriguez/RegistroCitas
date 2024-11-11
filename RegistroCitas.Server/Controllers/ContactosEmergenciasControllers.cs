using Microsoft.AspNetCore.Mvc;
using RegistroCitas.BD.Data.Entity;
using RegistroCitas.BD.Data;
using Microsoft.EntityFrameworkCore;
using RegistroCitas.Shared.DTO;
using AutoMapper;

namespace RegistroCitas.Server.Controllers
{
    public class ContactosEmergenciasControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public ContactosEmergenciasControllers(Context context,
                                               IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactosEmergencia>>> Get()
        {
            return await context.ContactosEmergencias.ToListAsync();
        }


        [HttpGet("{id:int}")] //api/ContactoEmergencias/2
        public async Task<ActionResult<ContactosEmergencia>> Get(int id)
        {
            ContactosEmergencia? pepe = await context.ContactosEmergencias
                .FirstOrDefaultAsync(x => x.Id == id);
            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearContactosEmergenciaDTO entidadDTO)
        {
            try //por si existe un error, puedo responder algunas cosas (que me de un entero o resultado de la acticion
            {
                ////ContactosEmergencia entidad = new ContactosEmergencia();
                ////entidad.Nombre = entidadDTO.Nombre;
                ////entidad.Relacion = entidadDTO.Relacion;
                ////entidad.Telefono = entidadDTO.Telefono;
                ////entidad.Email = entidadDTO.Email;

                ContactosEmergencia entidad = mapper.Map<ContactosEmergencia>(entidadDTO);
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
        public async Task<ActionResult> Put(int id, [FromBody] ContactosEmergencia entidad)
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
            ContactosEmergencia EntidadABorrar = new ContactosEmergencia();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
