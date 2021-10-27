using Senai_WishList_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_WishList_webAPI.Interfaces
{
    interface ILoginRepository
    {
        /// <summary>
        /// Método responsavel pelo login de Usuarios
        /// </summary>
        /// <param name="Email">Email para login</param>
        /// <param name="Senha">Senha para login</param>
        /// <returns>Um Usuario com aquele email e senha</returns>
        Usuario Login(string Email, string Senha);
    }
}
