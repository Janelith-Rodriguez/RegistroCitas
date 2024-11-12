using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroCitas.BD.Data;
using RegistroCitas.BD.Data.Entity;
using RegistroCitas.Server.Repositorio;

namespace RegistroCitas.Server.Controllers
{
    [ApiController]
    [Route("api/ TDocumentos")]
    public class TDocumentosControllers : ControllerBase
    {
        
        private readonly ITDocumentoRepositorio repositorio;

        public TDocumentosControllers(ITDocumentoRepositorio repositorio)
        {
            
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TDocumento>>>Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetBycod/{cod}")] //api/TDocumentos/GetByCod/DNI
        public async Task<ActionResult<TDocumento>>GetByCod(string cod)
        {
            TDocumento? pepe = await repositorio.SelectByCod(cod);
            if(pepe ==null)
            {
                return NotFound();
            }
            return pepe;
        }

        [HttpGet("{id:int}")] //api/TDocumentos/2
        public async Task<ActionResult<TDocumento>> Get(int id)
        {
            TDocumento? pepe = await repositorio.SelectById(id);
                
            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }
       
        [HttpGet("existe/{id:int}")]
        public async Task<ActionResult<bool>>Existe(int id)
        {
             
            return await repositorio.Existe(id);

        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Post(TDocumento entidad)
        {
            try //por si existe un error, puedo responder algunas cosas (que me de un entero o resultado de la acticion
            {
                
                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/TDocumentos/2
        public async Task<ActionResult> Put(int id,[FromBody] TDocumento entidad)                                                                              
        {
            try
            {
                if (id != entidad.Id)
                {
                    return BadRequest("Datos Incorrectos");
                }
                var pepe = await repositorio.Update(id, entidad);

                if (!pepe)
                {
                    return BadRequest("No se pudo actualizar el tipo de documento.");
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/TDocumentos/2
        public async Task<ActionResult> Delete(int id)
        {

            var resp = await repositorio.Delete(id);
            if (!resp)

            { return BadRequest("El tipo de documento no se pudo borrar"); }
            return Ok();
        }
    }
}
