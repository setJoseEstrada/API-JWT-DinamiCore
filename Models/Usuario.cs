using System;
using System.Collections.Generic;

#nullable disable

namespace DynamiCore.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Directorios = new HashSet<Directorio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string Curp { get; set; }

        public virtual ICollection<Directorio> Directorios { get; set; }
    }
}
