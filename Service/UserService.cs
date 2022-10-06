using DynamiCore.Models;
using DynamiCore.Models.Common;
using DynamiCore.Models.Request;
using DynamiCore.Models.Response;
using DynamiCore.Tools;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace DynamiCore.Service
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSetings;

        public UserService(IOptions<AppSettings> appSetings)
        {

            _appSetings = appSetings.Value;
        }
        public AccesoResponde Auth(AuthRequest model)
        {
            AccesoResponde response = new AccesoResponde();
            using (var db = new DynamicoreContext())
            {
                string scontrasena = Encrypt.GetSHA256(model.contrasena);

                var usuario = db.Accesos.Where(d => d.Correo == model.correo &&
                d.Contrasena == scontrasena).FirstOrDefault();
                if (usuario == null) return null;

                response.correo = usuario.Correo;

                response.Token = GetToken(usuario);



            }
            return response;
        }

        private string GetToken(Acceso usuario)
        {
            var tokenHanldler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSetings.Secreto);
            var tokenDescripcion = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Email, usuario.Correo)
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHanldler.CreateToken(tokenDescripcion);
            return tokenHanldler.WriteToken(token);
        }
    }
}
