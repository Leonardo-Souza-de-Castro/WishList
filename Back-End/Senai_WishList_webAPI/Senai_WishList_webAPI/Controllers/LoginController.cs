using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_WishList_webAPI.Domains;
using Senai_WishList_webAPI.Interfaces;
using Senai_WishList_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_WishList_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginRepository _loginRepository { get; set; }

        public LoginController()
        {
            _loginRepository = new LoginRepository();
        }

        /// <summary>
        /// Método responsavel por fazer o login dos Usuarios
        /// </summary>
        /// <param name="usuarioparalogar">Email e Senha do Usuario</param>
        /// <returns>O Token para login</returns>
        [HttpPost]
        public IActionResult Login(Usuario usuarioparalogar)
        {
            try
            {
                Usuario UsuarioBuscado = _loginRepository.Login(usuarioparalogar.Email, usuarioparalogar.Senha);

                if (UsuarioBuscado != null)
                {
                    var MinhasClains = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                    };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Senai_WishList_WebAPI"));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var meuToken = new JwtSecurityToken(
                        issuer: "WishList_webApi",
                        audience: "WishList_webApi",
                        claims: MinhasClains,
                        expires: DateTime.Now.AddHours(3),
                        signingCredentials: creds
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                    });
                }

                return BadRequest("Email ou Senha Ivalidos");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
