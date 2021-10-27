using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_WishList_webAPI.Domains
{
    public partial class Desejo
    {
        public int IdDesejo { get; set; }
        public string DescricaoDesejo { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
