using Senai_WishList_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_WishList_webAPI.Interfaces
{
    interface IDesejoRepository
    {
        /// <summary>
        /// Esse método é responsavel por listar todos os desejos cadastrados
        /// </summary>
        /// <returns>Uma lista de desejos</returns>
        List<Desejo> Listar();

        /// <summary>
        /// Método Responsavel pelo cadastro de novos desejos
        /// </summary>
        /// <param name="Desejo_Novo">O novo desejo a ser cadastrado</param>
        void Cadastrar(Desejo Desejo_Novo);
        
        /// <summary>
        /// Método Responsavel por listar os desejos do Usuario Logado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Desejo> ListarMinhas(int id);
    }
}
