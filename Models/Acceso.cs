using System;
using System.Collections.Generic;

#nullable disable

namespace DynamiCore.Models
{
    public partial class Acceso
    {
        public int Id { get; set; }
        
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
    }
}
