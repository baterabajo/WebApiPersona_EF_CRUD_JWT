
using MyDemoAPI.Entities;

namespace MyDemoAPI.Data
{
    public interface IAuthRespository 
    {
      
        Task<Persona> Registrar(Persona persona, string password);

        Task<Persona> Login(string correo, string password);

        Task<bool> Existspersona(string correo);
        
    }
}