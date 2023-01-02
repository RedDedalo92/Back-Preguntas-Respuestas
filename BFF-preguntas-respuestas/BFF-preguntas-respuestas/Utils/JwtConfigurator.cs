using BFF_preguntas_respuestas.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BFF_preguntas_respuestas.Utils
{
    public class JwtConfigurator
    {
        public static string GetToken(Usuario userInfo, IConfiguration config)
        {
            string secretKey = config["Jwt:SecretKey"];
            string issuer = config["Jwt:Issuer"];
            string audience = config["Jwt:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.NombreUsuario),
                new Claim("idUsuario", userInfo.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static int getTokenIdUsuario(ClaimsIdentity identity)
        {
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;

                foreach (var claim in claims)
                {
                    if (claim.Type == "idUsuario")
                    {
                        return Convert.ToInt32(claim.Value);
                    }
                }
            }
            return 0;
        }
    }
}
