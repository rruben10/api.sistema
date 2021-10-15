using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.sistema.Models
{
    [MetadataType(typeof(productos.MetaData))]
    public partial class productos
    {
        sealed class MetaData
        {
            [Required]
            public string descripcion;
            [Required]
            public string modelo;
            [Required]
            public int precio;
            [Required]
            public short existencia;
        }
    }
}