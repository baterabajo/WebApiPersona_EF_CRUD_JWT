using MyDemoAPI.Entities;

namespace MyDemoAPI.Services
{
    public interface IConsumirAPIPersonaService
    {
      
        Task<List<Persona>> GetPersonas();

    }
}