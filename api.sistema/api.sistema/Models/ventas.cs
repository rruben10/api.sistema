//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace api.sistema.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ventas
    {
        public long id { get; set; }
        public Nullable<long> cliente { get; set; }
        public Nullable<long> producto { get; set; }
        public int enganche { get; set; }
        public int bonificacionEnganche { get; set; }
        public int total { get; set; }
    
        public virtual clientes clientes { get; set; }
        public virtual productos productos { get; set; }
    }
}
