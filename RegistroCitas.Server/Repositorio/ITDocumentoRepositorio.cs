using RegistroCitas.BD.Data.Entity;

namespace RegistroCitas.Server.Repositorio
{
    public interface ITDocumentoRepositorio : IRepositorio<TDocumento>
    {
        Task<TDocumento> SelectByCod(string cod);
    }
}
