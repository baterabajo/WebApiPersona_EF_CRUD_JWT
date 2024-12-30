
namespace MyDemoAPI.Entities
{
    public class Persona
    {
        public int Id { get; set; }

        public string Nombre { get; set; }  

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public bool Activo { get; set; }

        public string correo { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }


        private DateTime FechaNacimiento => DateTime.Now.AddYears(-Edad);

   

    }




}