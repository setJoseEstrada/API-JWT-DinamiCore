using System;
using System.Collections.Generic;

#nullable disable

namespace DynamiCore.Models
{
    public partial class Directorio
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdContacto { get; set; }

        public virtual Contacto IdContactoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
