using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace RegistroCitas.Client.Autorizacion
{
    public class ProveedorAutenticacion : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // throw new NotImplementedException();
            //await Task.Delay(1000);
            var anonimo = new ClaimsIdentity();
            var usuarioPepe = new ClaimsIdentity(
                new List<Claim>
                {
                     new Claim(ClaimTypes.Name, "pepe"),
                     new Claim(ClaimTypes.Role, "operador"),
                     new Claim("DNI", "12,456.377")
                },
                authenticationType: "ok"                
                );
             return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(usuarioPepe)));  
       
        }
    }
}
