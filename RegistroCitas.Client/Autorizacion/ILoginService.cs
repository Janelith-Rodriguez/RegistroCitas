using RegistroCitas.Shared.DTO;

namespace RegistroCitas.Client.Autorizacion
{
    public interface ILoginService
    {
        Task Login(UserTokenDTO tokenDTO);
        Task Logout();
    }
}