using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistroCitas.BD.Data.Entity;
using RegistroCitas.Server.Repositorio;
using RegistroCitas.Shared.DTO;

namespace RegistroCitas.Server.Controllers
{
    [ApiController]
    [Route("api/Personas")]
    public class PersonasControllers : ControllerBase
    {
        private readonly IPersonaRepositorio repositorio;

        //private readonly Context context;
        private readonly IMapper mapper;

        public PersonasControllers(IPersonaRepositorio repositorio,
                                               IMapper mapper) //Context context
        {
            //this.context = context;
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return await repositorio.Select();
        }


        [HttpGet("{id:int}")] //api/Personas/2
        public async Task<ActionResult<Persona>> Get(int id)
        {

                Persona? pepe = await repositorio.SelectById(id);

            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPersonaDTO entidadDTO)
        {
            try //por si existe un error, puedo responder algunas cosas (que me de un entero o resultado de la accion
            {

                Persona entidad = mapper.Map<Persona>(entidadDTO);


                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Personas/2
        public async Task<ActionResult> Put(int id, [FromBody] Persona entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var pepe = await repositorio.SelectById(id);

            if (pepe == null)
            {
                return NotFound("No existe la persona buscada.");
            }

            pepe.NumDoc = entidad.NumDoc;
            pepe.Nombre = entidad.Nombre;
            pepe.Apellido = entidad.Apellido;
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

        [HttpDelete("{id:int}")] //api/Personas/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"La persona {id} no existe.");
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
