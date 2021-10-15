using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.sistema.Models
{
    [MetadataType(typeof(ventas.MetaData))]
    public partial class ventas
    {
        sealed class MetaData
        {
            [Required]
            public long cliente;
            [Required]
            public long producto;
            [Required]
            public int enganche;
            [Required]
            public int bonificacionEnganche;
            [Required]
            public int total;
        }
    }
}