using Senai_WishList_webAPI.Contexts;
using Senai_WishList_webAPI.Domains;
using Senai_WishList_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_WishList_webAPI.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        WishListContext ctx = new WishListContext();
        public Usuario Login(string Email, string Senha)
        {
            return ctx.Usuarios.FirstOrDefault(U => U.Email == Email && U.Senha == Senha);
        }
    }
}
