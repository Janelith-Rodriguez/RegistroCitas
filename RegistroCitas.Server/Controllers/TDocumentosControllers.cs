using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using RegistroCitas.BD.Data;
using RegistroCitas.BD.Data.Entity;
using RegistroCitas.Server.Repositorio;

namespace RegistroCitas.Server.Controllers
{
    [ApiController]
    [Route("api/TDocumentos")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TDocumentosControllers : ControllerBase
    {
        
        private readonly ITDocumentoRepositorio repositorio;
        private readonly IOutputCacheStore outputCacheStore;

        private const string cacheKey = "TDocumentos";

        public TDocumentosControllers(ITDocumentoRepositorio repositorio,
            IOutputCacheStore outputCacheStore)
        {
            
            this.repositorio = repositorio;
            this.outputCacheStore = outputCacheStore;
           
        }

        [HttpGet]
        [OutputCache(Tags = [cacheKey])]
        [AllowAnonymous]
        public async Task<ActionResult<List<TDocumento>>>Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetBycod/{cod}")] //api/TDocumentos/GetByCod/DNI
        [OutputCache(Tags = [cacheKey])]
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
        [OutputCache(Tags = [cacheKey])]
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
        [OutputCache(Tags = [cacheKey])]
        public async Task<ActionResult<bool>>Existe(int id)
        {
             
            return await repositorio.Existe(id);

        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Post(TDocumento entidad)
        {
            try //por si existe un error, puedo responder algunas cosas (que me de un entero o resultado de la acticion
            {
                var id = await repositorio.Insert(entidad);
                if (id == 0)
                {
                    return BadRequest("No se pudo insertar el tipo de documento");
                }
                await outputCacheStore.EvictByTagAsync(cacheKey, default);

                return id;
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
                await outputCacheStore.EvictByTagAsync(cacheKey, default);
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
            await outputCacheStore.EvictByTagAsync(cacheKey, default);
            return Ok();
        }
    }
}
