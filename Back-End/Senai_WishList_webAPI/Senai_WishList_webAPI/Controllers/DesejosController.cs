using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_WishList_webAPI.Domains;
using Senai_WishList_webAPI.Interfaces;
using Senai_WishList_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_WishList_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DesejosController : ControllerBase
    {
        private IDesejoRepository _desejoRepository { get; set; }

        public DesejosController()
        {
            _desejoRepository = new DesejoRepository();
        }

        /// <summary>
        /// Esse método é responsavel por listar todos os desejos cadastrados
        /// </summary>
        /// <returns>Uma lista de desejos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_desejoRepository.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Método Responsavel por listar os desejos do Usuario Logado
        /// </summary>
        /// <returns> Uma lista de desejos</returns>
        [HttpGet]
        public IActionResult ListarMinhas()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(_desejoRepository.ListarMinhas(id));
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    mensagem = "É necessario estar logado para ver as suas consultas"
                });
            }
        }

        /// <summary>
        /// Método Responsavel pelo cadastro de novos desejos
        /// </summary>
        /// <param name="DesejoNovo">O novo desejo a ser cadastrado</param>
        [HttpPost]
        public IActionResult Cadastrar(Desejo DesejoNovo)
        {
            try
            {
                _desejoRepository.Cadastrar(DesejoNovo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
