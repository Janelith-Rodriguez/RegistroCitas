using Microsoft.AspNetCore.Mvc;
using RegistroCitas.BD.Data.Entity;
using RegistroCitas.BD.Data;
using Microsoft.EntityFrameworkCore;
using RegistroCitas.Shared.DTO;
using AutoMapper;
using RegistroCitas.Server.Repositorio;

namespace RegistroCitas.Server.Controllers
{
    [ApiController]
    [Route("api/ContactosEmergencias")]
    public class ContactosEmergenciasControllers : ControllerBase
    {
        private readonly IContactosEmergenciaRepositorio repositorio;

        //private readonly Context context;
        private readonly IMapper mapper;

        public ContactosEmergenciasControllers(IContactosEmergenciaRepositorio repositorio,
                                               IMapper mapper) //Context context
        {
            //this.context = context;
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactosEmergencia>>> Get()
        {
            return await repositorio.Select();
        }


        [HttpGet("{id:int}")] //api/ContactoEmergencias/2
        public async Task<ActionResult<ContactosEmergencia>> Get(int id)
        {

            ContactosEmergencia? pepe = await repositorio.SelectById(id);
                
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

               
                return await repositorio.Insert(entidad);
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
            var pepe = await repositorio.SelectById(id);

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
               await repositorio.Update(id, pepe);
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
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El tipo de Contacto de emergencia {id} no existe.");
            }
            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
