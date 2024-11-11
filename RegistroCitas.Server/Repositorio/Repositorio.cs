using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroCitas.BD.Data;
using RegistroCitas.BD.Data.Entity;
using RegistroCitas.Shared.DTO;

namespace RegistroCitas.Server.Repositorio
{
    public class Repositorio<E> :  IRepositorio<E>
                 where E : class, IEntityBase //repositorio trabaja sobre la entidad (E)
    {
        private readonly Context context;

        public Repositorio(Context context)
        {
            this.context = context;
        }
        public async Task<bool> Existe(int id)
        {
            var existe = await context.Set<E>()
                .AnyAsync(x => x.Id == id);
            return existe;

        }

        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }
        public async Task<E> SelectById(int id)
        {
            E? pepe = await context.Set<E>().AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return pepe;
        }

        public async Task<int> Insert(E entidad)
        {
            try //por si existe un error, puedo responder algunas cosas (que me de un entero o resultado de la acticion
            {

                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Update(int id, E entidad)
        {
            if (id != entidad.Id)
            {
                return false;
            }
            var pepe = await SelectById(id);

            if (pepe == null)
            {
                return false;
            }

            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var pepe = await SelectById(id);

            if (pepe == null)
            {
                return false;
            }

            context.Set<E>().Remove(pepe);
            await context.SaveChangesAsync();
            return true;
        }
    }
}      
