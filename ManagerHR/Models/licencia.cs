//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagerHR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    
    public partial class licencia
    {
        public int id { get; set; }
        public int idempleado { get; set; }
        public System.DateTime desde { get; set; }
        public System.DateTime hasta { get; set; }
        public string motivo { get; set; }
        public string comentario { get; set; }
    
        public virtual empleado empleado { get; set; }
    }
}
