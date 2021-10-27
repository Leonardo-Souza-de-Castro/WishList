using Microsoft.EntityFrameworkCore;
using Senai_WishList_webAPI.Contexts;
using Senai_WishList_webAPI.Domains;
using Senai_WishList_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_WishList_webAPI.Repositories
{
    public class DesejoRepository : IDesejoRepository
    {
        WishListContext ctx = new WishListContext();
        public void Cadastrar(Desejo Desejo_Novo, int id)
        {
            Desejo_Novo.IdUsuario = id;
            ctx.Desejos.Add(Desejo_Novo);

            ctx.SaveChanges();
        }

        public List<Desejo> Listar()
        {
            return ctx.Desejos.ToList();
        }

        public List<Desejo> ListarMinhas(int id)
        {
            return ctx.Desejos.Where(U => U.IdUsuario == id).ToList();
        }
    }
}
