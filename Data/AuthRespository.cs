using Microsoft.EntityFrameworkCore;
using MyDemoAPI.Entities;

namespace MyDemoAPI.Data
{    
    public class AuthRespository: IAuthRespository
    { 
       private readonly DataContext _context;
        public AuthRespository(DataContext context)
        {
            _context = context;
        }

        public async Task <bool> Existspersona(string correo)
        {
            if (await _context.Personas.AnyAsync(x => x.correo == correo))
                return true;

            return false;
        }
        public async Task<Persona> Login(string correo, string password)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(x => x.correo == correo);    
            if (persona == null)
                return null;
             if(!VerifyPasswordHash(password, persona.PasswordHash, persona.PasswordSalt))
                return null;

               return persona; 
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }


        public async Task<Persona> Registrar(Persona persona, string password)
        {
            byte[] passwordHash; 
            byte[] passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            persona.PasswordHash = passwordHash;
            persona.PasswordSalt = passwordSalt;

            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();

            return persona;
        } 

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }




    }

}